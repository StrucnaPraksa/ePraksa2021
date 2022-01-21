using PracticeManagement.Core;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.ViewModel;
using System;
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
            var practiceAttendances = _unitOfWork.PracticeAttendances.GetPracticeAttendances();
            return View(practiceAttendances);
        }

        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.MentorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult Details(int id)
        {
            var viewModel = new PracticeAttendanceDetailsViewModel
            {
                PracticeAttendance = _unitOfWork.PracticeAttendances.GetPracticeAttendance(id)
            };

            if (User.IsInRole(RoleName.StudentRoleName) && viewModel.PracticeAttendance.MentorConfirmation)
                return new HttpStatusCodeResult(409);

            return View(viewModel);
        }

        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult Create()
        {
            var viewModel = new PracticeAttendanceDetailsViewModel
            {
                PracticeAttendance = new PracticeAttendance()
                {
                    Date = DateTime.Now.Date,
                    TimeStart = DateTime.Now,
                    TimeEnd = DateTime.Now,
                }
            };

            return View("Details", viewModel);
        }

        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.MentorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult Save(PracticeAttendance practiceAttendance)
        {
            if (User.IsInRole(RoleName.StudentRoleName) && practiceAttendance.MentorConfirmation)
                return new HttpStatusCodeResult(409);

            if (practiceAttendance.TimeStart > practiceAttendance.TimeEnd)
                return new HttpStatusCodeResult(409);

            _unitOfWork.PracticeAttendances.UpdatePracticeAttendance(practiceAttendance);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult Delete(int id)
        {
            _unitOfWork.PracticeAttendances.DeletePracticeAttendance(id);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.MentorRoleName)]
        public ActionResult ToggleStatus(int id)
        {
            var attendance = _unitOfWork.PracticeAttendances.GetPracticeAttendance(id);
            attendance.MentorConfirmation = !attendance.MentorConfirmation;
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.MentorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult PracticeBreak(PracticeAttendance practiceAttendance)
        {
            return RedirectToAction("Index", "PracticeBreaks", new { id = practiceAttendance.Id });
        }
    }
}
