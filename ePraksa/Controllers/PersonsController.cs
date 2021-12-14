
using System.Web.Mvc;
using PracticeManagement.Core;
using PracticeManagement.Core.ViewModel;
using Microsoft.AspNet.Identity;

namespace PracticeManagement.Controllers
{
    [Authorize]
    public class PersonsController : Controller
    {
   


        private readonly IUnitOfWork _unitOfWork;

        public PersonsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var Persons = _unitOfWork.Persons.GetPersons();
            return View(Persons);
        }


        public ActionResult Details(int id)
        {
            var viewModel = new PersonDetailViewModel()
            {
                Person = _unitOfWork.Persons.GetPerson(id),
                Appointments = _unitOfWork.Appointments.GetAppointmentWithPatient(id),
                CountAppointments = _unitOfWork.Appointments.CountAppointments(id),
                CountAttendance = _unitOfWork.Attandences.CountAttendances(id)
            };
            return View("Details", viewModel);
        }

    }





}