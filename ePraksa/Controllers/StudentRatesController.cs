using System;
using System.Linq;
using System.Web.Mvc;
using PracticeManagement.Core;
using PracticeManagement.Core.ViewModel;
using PracticeManagement.Core.Models;
using Microsoft.AspNet.Identity;

namespace PracticeManagement.Controllers
{
    [Authorize]
    public class StudentRatesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentRatesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var StudentRates = _unitOfWork.StudentRates.GetStudentRates();
            return View(StudentRates);
        }

      //  [Authorize(Roles = RoleName.AdministratorRoleName)]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var StudentRates = _unitOfWork.StudentRates.GetStudentRate(id);
            _unitOfWork.StudentRates.Remove(StudentRates);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "StudentRates");
        }

       // [Authorize(Roles = RoleName.AdministratorRoleName)]
        [HttpPost]
        public ActionResult ToggleStatus(int id)
        {
            var StudentRates = _unitOfWork.StudentRates.GetStudentRate(id);
            StudentRates.Active = !StudentRates.Active;
            _unitOfWork.Complete();
            return RedirectToAction("Index", "StudentRates");
        }

      //  [Authorize(Roles = RoleName.MentorRoleName)]
        public ActionResult Create()
        {
            var viewModel = new StudentRateFormViewModel
            {
                StudentRates = _unitOfWork.StudentRates.GetStudentRates(),
                Students = _unitOfWork.Students.GetStudents(),
                Mentors = _unitOfWork.Mentors.GetMentors()
            };
            //return View("StudentRateFormViewModel", viewModel);
            return View("StudentRateFormViewModel", viewModel);
        }

      //  [Authorize(Roles = RoleName.MentorRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentRateFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {

                viewModel.StudentRates = _unitOfWork.StudentRates.GetStudentRates();
                return View("StudentRateFormViewModel", viewModel);

            }
            var studentRate = new StudentRate
            {

                Id = viewModel.Id,
                MentorsID = viewModel.MentorsID,
                A1 = viewModel.A1,
                A2 = viewModel.A2,
                A3 = viewModel.A3,
                A4 = viewModel.A4,
                A5 = viewModel.A5,
                Rate = viewModel.Rate,
                Active = viewModel.Active,
                StudentsID = viewModel.StudentsID,
                InternshipsID = viewModel.InternshipsID
            };

            _unitOfWork.StudentRates.Add(studentRate);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "StudentRates");

        }
        //[Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.StudentRoleName)]
       // [Authorize(Roles = RoleName.MentorRoleName)]
        public ActionResult Edit(int id)
        {
            var StudentRate = _unitOfWork.StudentRates.GetStudentRate(id);
            if (StudentRate == null) return HttpNotFound();

            var viewModel = new StudentRateFormViewModel()
            {

                A1 = StudentRate.A1,
                A2 = StudentRate.A2,
                A3 = StudentRate.A3,
                A4 = StudentRate.A4,
                A5 = StudentRate.A5,
                Rate = StudentRate.Rate,
                Active = StudentRate.Active,

            };
            return View(viewModel);
        }
       // [Authorize(Roles = RoleName.MentorRoleName)]
        [HttpPost]
        public ActionResult Edit(StudentRateFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                //viewModel.Faculties = _unitOfWork.Faculties.GetFaculties();
                //viewModel.Cities = _unitOfWork.Cities.GetCities();
                //viewModel.FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses();
                //viewModel.YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies();
                viewModel.StudentRates = _unitOfWork.StudentRates.GetStudentRates();
                return View(viewModel);
            }

            var StudentRateInDb = _unitOfWork.StudentRates.GetStudentRate(viewModel.Id);


            StudentRateInDb.A1 = viewModel.A1;
            StudentRateInDb.A2 = viewModel.A2;
            StudentRateInDb.A3 = viewModel.A3;
            StudentRateInDb.A4 = viewModel.A4;
            StudentRateInDb.A5 = viewModel.A5;
            StudentRateInDb.Rate = viewModel.Rate;
            StudentRateInDb.Active = viewModel.Active;



            _unitOfWork.Complete();

            return RedirectToAction("Index", new { id = viewModel.Id });
        }
        public ActionResult Update(int id)
        {
            var StudentRate = _unitOfWork.StudentRates.GetStudentRate(id);
            if (StudentRate == null) return HttpNotFound();

            var viewModel = new StudentRateFormViewModel()
            {
                Id = StudentRate.Id,
                MentorsID = StudentRate.MentorsID,
                A1 = StudentRate.A1,
                A2 = StudentRate.A2,
                A3 = StudentRate.A3,
                A4 = StudentRate.A4,
                A5 = StudentRate.A5,
                Rate = StudentRate.Rate,
                Active = StudentRate.Active,
                StudentsID = StudentRate.StudentsID,
                StudentRates = _unitOfWork.StudentRates.GetStudentRates()
                //Cities = _unitOfWork.Cities.GetCities(),
                //YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies(),
                //Faculties = _unitOfWork.Faculties.GetFaculties(),
                //FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses(),
            };
            return View(viewModel);
        }
        //[Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.StudentRoleName)]
        [HttpPost]
        public ActionResult Update(StudentRateFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                //viewModel.Faculties = _unitOfWork.Faculties.GetFaculties();
                //viewModel.Cities = _unitOfWork.Cities.GetCities();
                //viewModel.FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses();
                //viewModel.YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies();
                viewModel.StudentRates = _unitOfWork.StudentRates.GetStudentRates();
                return View(viewModel);
            }

            var StudentRateInDb = _unitOfWork.StudentRates.GetStudentRate(viewModel.Id);
            StudentRateInDb.Id = viewModel.Id;
            StudentRateInDb.MentorsID = viewModel.MentorsID;
            StudentRateInDb.A1 = viewModel.A1;
            StudentRateInDb.A2 = viewModel.A2;
            StudentRateInDb.A3 = viewModel.A3;
            StudentRateInDb.A4 = viewModel.A4;
            StudentRateInDb.A5 = viewModel.A5;
            StudentRateInDb.Rate = viewModel.Rate;
            StudentRateInDb.Active = viewModel.Active;
            StudentRateInDb.StudentsID = viewModel.StudentsID;
            _unitOfWork.Complete();

            return RedirectToAction("Index", "StudentRates");
        }

        //public ActionResult Details(int id)
        //{
        //    var viewModel = new FacultyDetailViewModel()
        //    {
        //        Faculty = _unitOfWork.MentorRates.GetMentorRates(id),
        //        Appointments = _unitOfWork.Appointments.GetAppointmentWithPatient(id),
        //        //CountAppointments = _unitOfWork.Appointments.CountAppointments(id),
        //        //CountAttendance = _unitOfWork.Attandences.CountAttendances(id)
        //    };
        //    return View("Details", viewModel);
        //}


    }





}