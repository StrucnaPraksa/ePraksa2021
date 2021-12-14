
using System.Web.Mvc;
using PracticeManagement.Core;
using PracticeManagement.Core.ViewModel;
using Microsoft.AspNet.Identity;

namespace PracticeManagement.Controllers
{
    [Authorize]
    public class Faculties2Controller : Controller
    {
   


        private readonly IUnitOfWork _unitOfWork;

        public Faculties2Controller(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var Faculties2 = _unitOfWork.Faculties2.GetFaculties2();
            return View(Faculties2);
        }


        //public ActionResult Details(int id)
        //{
        //    var viewModel = new FakultetiDetailViewModel()
        //    {
        //        Faculty = _unitOfWork.Faculties.GetFaculties(),
        //        Appointments = _unitOfWork.Appointments.GetAppointmentWithPatient(id),
        //        //CountAppointments = _unitOfWork.Appointments.CountAppointments(id),
        //        //CountAttendance = _unitOfWork.Attandences.CountAttendances(id)
        //    };
        //    return View("Details", viewModel);
        //}

    }





}