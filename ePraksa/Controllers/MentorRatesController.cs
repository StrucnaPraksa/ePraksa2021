
using System.Web.Mvc;
using PracticeManagement.Core;
using PracticeManagement.Core.ViewModel;
using PracticeManagement.Core.Models;
using Microsoft.AspNet.Identity;

namespace PracticeManagement.Controllers
{
    [Authorize]
    public class MentorRatesController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public MentorRatesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var MentorRates = _unitOfWork.MentorRates.GetMentorRates();
            return View(MentorRates);
        }

        //[Authorize(Roles = RoleName.FirmaAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName)]
       //odkomentirat [Authorize(Roles = RoleName.AdministratorRoleName)]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var MentorRates = _unitOfWork.MentorRates.GetMentorRate(id);
            _unitOfWork.MentorRates.Remove(MentorRates);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "MentorRates");
        }

       //odkomentirat [Authorize(Roles = RoleName.AdministratorRoleName)]
        [HttpPost]
        public ActionResult ToggleStatus(int id)
        {
            var MentorRates = _unitOfWork.MentorRates.GetMentorRate(id);
            MentorRates.Activated = !MentorRates.Activated;
            _unitOfWork.Complete();
            return RedirectToAction("Index", "MentorRates");
        }
       // odkomentirat [Authorize(Roles = RoleName.StudentRoleName)]
        public ActionResult Create()
        {
            var viewModel = new MentorRateFormViewModel
            {
                MentorRates = _unitOfWork.MentorRates.GetMentorRates(),
                Mentors = _unitOfWork.Mentors.GetMentors(),
                Students = _unitOfWork.Students.GetStudents(),
                Internships = _unitOfWork.Internships.GetInternships()
            };
            //return View("MentorRateFormViewModel", viewModel);
            return View("MentorRateFormViewModel", viewModel);
        }
        //[Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.StudentRoleName)]
       // odkomentirat [Authorize(Roles = RoleName.StudentRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MentorRateFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {

                viewModel.MentorRates = _unitOfWork.MentorRates.GetMentorRates();
                return View("MentorRateFormViewModel", viewModel);

            }
            var mentorRate = new MentorRate
            {
                Id = viewModel.Id,
                MentorsID = viewModel.MentorsID,
                A1 = viewModel.A1,
                A2 = viewModel.A2,
                A3 = viewModel.A3,
                A4 = viewModel.A4,
                A5 = viewModel.A5,
                Rate = viewModel.Rate,
                Activated = viewModel.Activated,
                StudentsID = viewModel.StudentsID,
                InternshipsID = viewModel.InternshipsID
            };

            _unitOfWork.MentorRates.Add(mentorRate);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "MentorRates");

        }

       // odkomentirat [Authorize(Roles = RoleName.StudentRoleName)]
        public ActionResult Edit(int id)
        {
            var MentorRate = _unitOfWork.MentorRates.GetMentorRate(id);
            if (MentorRate == null) return HttpNotFound();

            var viewModel = new MentorRateFormViewModel()
            {
   
                A1 = MentorRate.A1,
                A2 = MentorRate.A2,
                A3 = MentorRate.A3,
                A4 = MentorRate.A4,
                A5 = MentorRate.A5,
                Rate = MentorRate.Rate,
                Activated = MentorRate.Activated

            };
            return View(viewModel);
        }
       // odkomentirat [Authorize(Roles = RoleName.StudentRoleName)]
        [HttpPost]
        public ActionResult Edit(MentorRateFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                //viewModel.Faculties = _unitOfWork.Faculties.GetFaculties();
                //viewModel.Cities = _unitOfWork.Cities.GetCities();
                //viewModel.FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses();
                //viewModel.YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies();
                viewModel.MentorRates = _unitOfWork.MentorRates.GetMentorRates();
                return View(viewModel);
            }

            var MentorRateInDb = _unitOfWork.MentorRates.GetMentorRate(viewModel.Id);

            MentorRateInDb.A1 = viewModel.A1;
            MentorRateInDb.A2 = viewModel.A2;
            MentorRateInDb.A3 = viewModel.A3;
            MentorRateInDb.A4 = viewModel.A4;
            MentorRateInDb.A5 = viewModel.A5;
            MentorRateInDb.Rate = viewModel.Rate;
            MentorRateInDb.Activated = viewModel.Activated;


            _unitOfWork.Complete();

            return RedirectToAction("Index", new { id = viewModel.Id });
        }
        public ActionResult Update(int id)
        {
            var MentorRate = _unitOfWork.MentorRates.GetMentorRate(id);
            if (MentorRate == null) return HttpNotFound();

            var viewModel = new MentorRateFormViewModel()
            {
                Id = MentorRate.Id,
                MentorsID = MentorRate.MentorsID,
                A1 = MentorRate.A1,
                A2 = MentorRate.A2,
                A3 = MentorRate.A3,
                A4 = MentorRate.A4,
                A5 = MentorRate.A5,
                Rate = MentorRate.Rate,
                Activated = MentorRate.Activated,
                StudentsID = MentorRate.StudentsID,
                //StudentRates = _unitOfWork.StudentRates.GetStudentRates(),
                MentorRates = _unitOfWork.MentorRates.GetMentorRates()
                //Cities = _unitOfWork.Cities.GetCities(),
                //YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies(),
                //Faculties = _unitOfWork.Faculties.GetFaculties(),
                //FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses(),
            };
            return View(viewModel);
        }
        //[Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.StudentRoleName)]
        [HttpPost]
        public ActionResult Update(MentorRateFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                //viewModel.Faculties = _unitOfWork.Faculties.GetFaculties();
                //viewModel.Cities = _unitOfWork.Cities.GetCities();
                //viewModel.FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses();
                //viewModel.YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies();
                //viewModel.StudentRates = _unitOfWork.StudentRates.GetStudentRates();
                viewModel.MentorRates = _unitOfWork.MentorRates.GetMentorRates();
                return View(viewModel);
            }

            var MentorRateInDb = _unitOfWork.MentorRates.GetMentorRate(viewModel.Id);
            MentorRateInDb.Id = viewModel.Id;
            MentorRateInDb.MentorsID = viewModel.MentorsID;
            MentorRateInDb.A1 = viewModel.A1;
            MentorRateInDb.A2 = viewModel.A2;
            MentorRateInDb.A3 = viewModel.A3;
            MentorRateInDb.A4 = viewModel.A4;
            MentorRateInDb.A5 = viewModel.A5;
            MentorRateInDb.Rate = viewModel.Rate;
            MentorRateInDb.Activated = viewModel.Activated;
            MentorRateInDb.StudentsID = viewModel.StudentsID;
            _unitOfWork.Complete();

            return RedirectToAction("Index", "MentorRates");
        }

        /*  public ActionResult Edit(int id)
          {
              var MentorRates = _unitOfWork.MentorRates.GetMentorRate(id);
              var viewModel = new MentorRateFormViewModel()
              {
                  Heading = "Edit Mentor rate",
                  Id = MentorRates.Id,
                  FirstName = MentorRates.Mentors.FirstName,
                  Title = MentorRates.Mentors.Title,
                  Occupation = MentorRates.Mentors.Occupation,
                  FirmId = MentorRates.Mentors.FirmId,
                  YearsOfExperience = MentorRates.Mentors.YearsOfExperience,
                  Firms = _unitOfWork.Firms.GetFirms()
              };
              return View(viewModel);
          }
          //[Authorize(Roles = RoleName.FirmaAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName)]
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit(MentorRateFormViewModel viewModel)
          {
              if (!ModelState.IsValid)
              {
                  viewModel.Firms = _unitOfWork.Firms.GetFirms();
                  return View(viewModel);
              }

              var MentorRates = _unitOfWork.MentorRates.GetMentorRate(viewModel.Id);
           MentorRates.Id = viewModel.Id;
           MentorRates.FirstName = viewModel.FirstName;
           MentorRates.Mentors.Title = viewModel.Title;
           MentorRates.Mentors.Occupation = viewModel.Occupation;
           MentorRates.Mentors.YearsOfExperience = viewModel.YearsOfExperience;
           MentorRates.Mentors.FirmId = viewModel.FirmId;
              _unitOfWork.Complete();
              return RedirectToAction("Index", "MentorRates");

          }*/

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