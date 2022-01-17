using System.Web.Mvc;
using PracticeManagement.Core;
using System.Collections.Generic;
using PracticeManagement.Core.ViewModel;
using PracticeManagement.Core.Models;
using Microsoft.AspNet.Identity;
using System.Linq;

namespace PracticeManagement.Controllers
{
    [Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.MentorRoleName + "," + RoleName.StudentRoleName)]
    public class GradesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;



        public GradesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var Grades = _unitOfWork.Grades.GetGrades();
            return View(Grades);
        }

        public ActionResult Create()
        {
            var viewModel = new GradeFormViewModel
            {
                Profesors = _unitOfWork.Profesors.GetProfesors(),
                Firms = _unitOfWork.Firms.GetFirms(),
                Students = _unitOfWork.Students.GetStudents(),
                Mentors = _unitOfWork.Mentors.GetMentors(),
                Internships = _unitOfWork.Internships.GetInternships(),
                Heading = "New Grade"
            };
            return View("GradeForm", viewModel);
        }

        [Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.MentorRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GradeFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.PracticeTypes = _unitOfWork.PracticeTypes.GetPracticeTypes();
                return View("GradeForm", viewModel);

            }

            var grade = new Grade
            {
                Id = viewModel.Id,
                PracticeId = viewModel.PracticeId,
                MentorId = viewModel.MentorId,
                ProfesorId = viewModel.ProfesorId,
                StudentId = viewModel.StudentId,
                FirmId = viewModel.FirmId,
                PGrade1 = viewModel.PGrade1,
                PGrade2 = viewModel.PGrade2,
                PGrade3 = viewModel.PGrade3,
                MGrade1 = viewModel.MGrade1,
                MGrade2 = viewModel.MGrade2,
                MGrade3 = viewModel.MGrade3,
                ProfesorComment = viewModel.ProfesorComment,
                MentorComment = viewModel.MentorComment
            };

            _unitOfWork.Grades.Add(grade);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Grades");

            // TODO: BUG redirect to detail 
            //return RedirectToAction("Details", new { id = viewModel.Id });
        }

        [Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.MentorRoleName)]
        public ActionResult Edit(int id)
        {
            var grade = _unitOfWork.Grades.GetGrade(id);
            var viewModel = new GradeFormViewModel
            {
                Heading = "Edit Grade",
                PGrade1 = grade.PGrade1,
                PGrade2 = grade.PGrade2,
                PGrade3 = grade.PGrade3,
                MGrade1 = grade.MGrade1,
                MGrade2 = grade.MGrade2,
                MGrade3 = grade.MGrade3,
                ProfesorComment = grade.ProfesorComment,
                MentorComment = grade.MentorComment
            };



            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GradeFormViewModel viewModel)
        {
   

            var grade = _unitOfWork.Grades.GetGrade(viewModel.Id);

            grade.PGrade1 = viewModel.PGrade1;
            grade.PGrade2 = viewModel.PGrade2;
            grade.PGrade3 = viewModel.PGrade3;
            grade.MGrade1 = viewModel.MGrade1;
            grade.MGrade2 = viewModel.MGrade2;
            grade.MGrade3 = viewModel.MGrade3;
            grade.ProfesorComment = viewModel.ProfesorComment;
            grade.MentorComment = viewModel.MentorComment;

            _unitOfWork.Complete();
            return RedirectToAction("Index", "Grades");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(GradeFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.PracticeTypes = _unitOfWork.PracticeTypes.GetPracticeTypes();
                viewModel.Firms = _unitOfWork.Firms.GetFirms();
                viewModel.Mentors = _unitOfWork.Mentors.GetMentors();
                viewModel.Profesors = _unitOfWork.Profesors.GetProfesors();
                viewModel.Students = _unitOfWork.Students.GetStudents();
                return View("GradeForm", viewModel);
            }


            var gradeInDb = _unitOfWork.Grades.GetGrade(viewModel.Id);
            gradeInDb.Id = viewModel.Id;
            gradeInDb.PracticeId = viewModel.PracticeId;
            gradeInDb.MentorId = viewModel.MentorId;
            gradeInDb.ProfesorId = viewModel.ProfesorId;
            gradeInDb.StudentId = viewModel.StudentId;
            gradeInDb.FirmId = viewModel.FirmId;
            gradeInDb.PGrade1 = viewModel.PGrade1;
            gradeInDb.PGrade2 = viewModel.PGrade2;
            gradeInDb.PGrade3 = viewModel.PGrade3;
            gradeInDb.MGrade1 = viewModel.MGrade1;
            gradeInDb.MGrade2 = viewModel.MGrade2;
            gradeInDb.MGrade3 = viewModel.MGrade3;
            gradeInDb.ProfesorComment = viewModel.ProfesorComment;
            gradeInDb.MentorComment = viewModel.MentorComment;


            _unitOfWork.Complete();
            return RedirectToAction("Index", "Grades")
;
        }
        [Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.MentorRoleName)]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var grade = _unitOfWork.Grades.GetGrade(id);
            _unitOfWork.Grades.Remove(grade);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Grades");
        }

        public ActionResult Details(int id)
        {
            var viewModel = new GradeDetailViewModel()
            {
                Grade = _unitOfWork.Grades.GetGrade(id)
            };
            return View("Details", viewModel);
        }





    }
}