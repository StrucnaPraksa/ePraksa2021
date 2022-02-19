using PracticeManagement.Core;
using PracticeManagement.Core.Helpers;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.ViewModel;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PracticeManagement.Controllers
{
    public class PracticeAttendancesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PracticeAttendancesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.MentorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult Index()
        {
            var userId = IdentityHelpers.GetUserId(User);
            var isStudent = User.IsInRole(RoleName.StudentRoleName);

            var practiceAttendances = _unitOfWork.PracticeAttendances.GetPracticeAttendances(userId, isStudent);
            return View("Index", practiceAttendances);
        }

        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.MentorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult PracticeBreak(PracticeAttendance practiceAttendance)
        {
            return DetailsAttendance(practiceAttendance.Id);
        }

        [HttpPost]
        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.MentorRoleName)]
        public ActionResult ToggleStatus(int id)
        {
            var attendance = _unitOfWork.PracticeAttendances.GetPracticeAttendance(id);
            attendance.MentorConfirmation = !attendance.MentorConfirmation;
            _unitOfWork.Complete();

            return Index();
        }

        #region Attendances

        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.MentorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult DetailsAttendance(int id)
        {
            var viewModel = new PracticeAttendanceDetailsViewModel
            {
                PracticeAttendance = _unitOfWork.PracticeAttendances.GetPracticeAttendance(id),
                PracticeBreaks = _unitOfWork.PracticeBreaks.GetPracticeBreaks(id),
            };

            return View("Details", viewModel);
        }

        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult CreateAttendance()
        {
            var studentId = IdentityHelpers.GetUserId(User);
            var viewModel = new PracticeAttendanceDetailsViewModel
            {
                PracticeAttendance = new PracticeAttendance()
                {
                    Date = DateTime.Now.Date,
                    TimeStart = DateTime.Now,
                    TimeEnd = DateTime.Now,
                    StudentId = _unitOfWork.PracticeAttendances.GetStudentId(studentId)
                },
                PracticeBreaks = Enumerable.Empty<PracticeBreak>()
            };

            return View("Details", viewModel);
        }

        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.MentorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult SaveAttendance(PracticeAttendanceDetailsViewModel practiceAttendanceDetailsVM)
        {
            var praticeAttendanceEntity = _unitOfWork.PracticeAttendances.GetPracticeAttendance(practiceAttendanceDetailsVM.PracticeAttendance.Id);

            if (practiceAttendanceDetailsVM.PracticeAttendance.TimeStart < practiceAttendanceDetailsVM.PracticeAttendance.TimeEnd &&
                User.IsInRole(RoleName.StudentRoleName) && !practiceAttendanceDetailsVM.PracticeAttendance.MentorConfirmation ||
                User.IsInRole(RoleName.MentorRoleName) && (practiceAttendanceDetailsVM.PracticeAttendance.MentorConfirmation != praticeAttendanceEntity.MentorConfirmation))
            {
                _unitOfWork.PracticeAttendances.UpdatePracticeAttendance(practiceAttendanceDetailsVM.PracticeAttendance);
                _unitOfWork.Complete();
            }

            return Index();
        }

        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult DeleteAttendance(int id)
        {
            _unitOfWork.PracticeAttendances.DeletePracticeAttendance(id);
            _unitOfWork.Complete();

            return Index();
        }

        #endregion

        #region Breaks

        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.MentorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult DetailsBreak(int id)
        {
            var viewModel = new PracticeBreakDetailsViewModel
            {
                PracticeBreak = _unitOfWork.PracticeBreaks.GetPracticeBreak(id)
            };

            return View("BreakDetails", viewModel);
        }

        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult CreateBreak(int practiceAttendanceId)
        {
            var practiceAttendance = _unitOfWork.PracticeAttendances.GetPracticeAttendance(practiceAttendanceId);
            if (practiceAttendance == null)
                return CreateAttendance();

            var viewModel = new PracticeBreakDetailsViewModel
            {
                PracticeBreak = new PracticeBreak()
                {
                    PracticeAttendanceId = practiceAttendanceId,
                    PracticeAttendance = practiceAttendance,
                }
            };

            return View("BreakDetails", viewModel);
        }

        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult SaveBreak(PracticeBreakDetailsViewModel practiceBreakVM)
        {
            if (practiceBreakVM.PracticeBreak.TimeStart > practiceBreakVM.PracticeBreak.TimeEnd)
                return new HttpStatusCodeResult(409);

            var breakRange = new Range<DateTime>(practiceBreakVM.PracticeBreak.TimeStart, practiceBreakVM.PracticeBreak.TimeEnd);

            var breaks = _unitOfWork.PracticeBreaks.GetPracticeBreaks(practiceBreakVM.PracticeBreak.PracticeAttendanceId);
            foreach (var @break in breaks)
            {
                var range = new Range<DateTime>(@break.TimeStart, @break.TimeEnd);

                if (range.IsOverlapped(breakRange))
                    return new HttpStatusCodeResult(409);
            }

            _unitOfWork.PracticeBreaks.UpdatePracticeBreak(practiceBreakVM.PracticeBreak);
            _unitOfWork.Complete();

            return DetailsAttendance(practiceBreakVM.PracticeBreak.PracticeAttendanceId);
        }

        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult DeleteBreak(int id, int practiceAttendanceId)
        {
            _unitOfWork.PracticeBreaks.DeletePracticeBreak(id);
            _unitOfWork.Complete();

            return DetailsAttendance(practiceAttendanceId);
        }

        #endregion
    }
}
