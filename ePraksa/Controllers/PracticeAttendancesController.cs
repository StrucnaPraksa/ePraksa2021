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

        public ActionResult Index()
        {
            var practiceAttendances = _unitOfWork.PracticeAttendances.GetPracticeAttendances();
            return View(practiceAttendances);
        }

        public ActionResult Details(int id)
        {
            var viewModel = new PracticeAttendanceDetailsViewModel
            {
                PracticeAttendance = _unitOfWork.PracticeAttendances.GetPracticeAttendance(id)
            };

            return View(viewModel);
        }

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

        public ActionResult Save(PracticeAttendance practiceAttendance)
        {
            if (practiceAttendance.TimeStart > practiceAttendance.TimeEnd)
                return new HttpStatusCodeResult(409);

            _unitOfWork.PracticeAttendances.UpdatePracticeAttendance(practiceAttendance);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _unitOfWork.PracticeAttendances.DeletePracticeAttendance(id);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult ToggleStatus(int id)
        {
            var attendance = _unitOfWork.PracticeAttendances.GetPracticeAttendance(id);
            attendance.MentorConfirmation = !attendance.MentorConfirmation;
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        public ActionResult PracticeBreak(PracticeAttendance practiceAttendance)
        {
            return RedirectToAction("Index", "PracticeBreaks", new { id = practiceAttendance.Id });
        }
    }
}
