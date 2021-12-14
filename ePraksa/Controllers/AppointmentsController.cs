using System.Linq;
using System.Web.Mvc;
using PracticeManagement.Core;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.ViewModel;

namespace PracticeManagement.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var appointments = _unitOfWork.Appointments.GetAppointments();
            return View(appointments);
        }

        public ActionResult Details(int id)
        {
            var appointment = _unitOfWork.Appointments.GetAppointmentWithPatient(id);
            return View("_AppointmentPartial", appointment);
        }
        //public ActionResult Patients(int id)
        //{
        //    var viewModel = new ProfesorDetailViewModel()
        //    {
        //        Appointments = _unitOfWork.Appointments.GetAppointmentByProfesor(id),
        //    };
        //    //var upcomingAppnts = _unitOfWork.Appointments.GetAppointmentByProfesor(id);
        //    return View(viewModel);
        //}

        public ActionResult Create(int id)
        {
            var viewModel = new AppointmentFormViewModel
            {
                Patient = id,
                Profesors = _unitOfWork.Profesors.GetAvailableProfesors(),

                Heading = "New Appointment"
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Profesors = _unitOfWork.Profesors.GetAvailableProfesors();
                return View(viewModel);

            }
            var appointment = new Appointment()
            {
                StartDateTime = viewModel.GetStartDateTime(),
                Detail = viewModel.Detail,
                Status = false,
                PatientId = viewModel.Patient,
                Profesor = _unitOfWork.Profesors.GetProfesor(viewModel.Profesor)

            };
            //Check if the slot is available
            if (_unitOfWork.Appointments.ValidateAppointment(appointment.StartDateTime, viewModel.Profesor))
                return View("InvalidAppointment");

            _unitOfWork.Appointments.Add(appointment);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Appointments");
        }

        public ActionResult Edit(int id)
        {
            var appointment = _unitOfWork.Appointments.GetAppointment(id);
            var viewModel = new AppointmentFormViewModel()
            {
                Heading = "New Appointment",
                Id = appointment.Id,
                Date = appointment.StartDateTime.ToString("dd/MM/yyyy"),
                Time = appointment.StartDateTime.ToString("HH:mm"),
                Detail = appointment.Detail,
                Status = appointment.Status,
                Patient = appointment.PatientId,
                Profesor = appointment.ProfesorId,
                //Patients = _unitOfWork.Patients.GetPatients(),
                Profesors = _unitOfWork.Profesors.GetProfesors()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AppointmentFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Profesors = _unitOfWork.Profesors.GetProfesors();
                viewModel.Patients = _unitOfWork.Patients.GetPatients();
                return View(viewModel);
            }

            var appointmentInDb = _unitOfWork.Appointments.GetAppointment(viewModel.Id);
            appointmentInDb.Id = viewModel.Id;
            appointmentInDb.StartDateTime = viewModel.GetStartDateTime();
            appointmentInDb.Detail = viewModel.Detail;
            appointmentInDb.Status = viewModel.Status;
            appointmentInDb.PatientId = viewModel.Patient;
            appointmentInDb.ProfesorId = viewModel.Profesor;

            _unitOfWork.Complete();
            return RedirectToAction("Index");

        }

        public ActionResult ProfesorsList()
        {
            var Profesors = _unitOfWork.Profesors.GetAvailableProfesors();
            if (HttpContext.Request.IsAjaxRequest())
                return Json(new SelectList(Profesors.ToArray(), "Id", "Name"), JsonRequestBehavior.AllowGet);
            return RedirectToAction("Create");
        }

        public PartialViewResult GetUpcommingAppointments(int id)
        {
            var appointments = _unitOfWork.Appointments.GetTodaysAppointments(id);
            return PartialView(appointments);
        }

    }
}