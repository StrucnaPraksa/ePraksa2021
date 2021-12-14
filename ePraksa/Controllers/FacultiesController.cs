
using System.Web.Mvc;
using PracticeManagement.Core;
using PracticeManagement.Core.ViewModel;
using Microsoft.AspNet.Identity;

namespace PracticeManagement.Controllers
{
    [Authorize]
    public class FacultiesController : Controller
    {
   


        private readonly IUnitOfWork _unitOfWork;

        public FacultiesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var Faculties = _unitOfWork.Faculties.GetFaculties();
            return View(Faculties);
        }


        public ActionResult Details(int id)
        {
            var viewModel = new FacultyDetailViewModel()
            {
                Faculty = _unitOfWork.Faculties.GetFaculty(id),
                Appointments = _unitOfWork.Appointments.GetAppointmentWithPatient(id),
                //CountAppointments = _unitOfWork.Appointments.CountAppointments(id),
                //CountAttendance = _unitOfWork.Attandences.CountAttendances(id)
            };
            return View("Details", viewModel);
        }

        
    }





}