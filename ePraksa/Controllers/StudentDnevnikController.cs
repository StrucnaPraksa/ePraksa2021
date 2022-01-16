using System.Web.Mvc;
using PracticeManagement.Core;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.ViewModel;

namespace PracticeManagement.Controllers
{
    [Authorize]
    public class StudentDnevnikController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentDnevnikController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            var StudentDnevnik = _unitOfWork.StudentDnevniks.GetStudentDnevniks();
            return View(StudentDnevnik);
        }

        public ActionResult Create()
        {
            var viewModel = new StudentDnevnikFormViewModel
            {
                StudentDnevniks = _unitOfWork.StudentDnevniks.GetStudentDnevniks(),
                Heading = "New Student"
            };
            return View("StudentDnevnikForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentDnevnikFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.StudentDnevniks = _unitOfWork.StudentDnevniks.GetStudentDnevniks();
                return View("StudentDnevnikFormViewModel", viewModel);

            }

            var studentDnevnik = new StudentDnevnik
            {
                studentPraksaId = 1,
                datum = System.DateTime.Now,
                aktivnost = viewModel.aktivnost,
                linkovi = viewModel.linkovi,
                dodatno = viewModel.dodatno,
                komentar = viewModel.komentar
            };

            _unitOfWork.StudentDnevniks.Add(studentDnevnik);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "StudentDnevnik");
        }
        public ActionResult Edit(int id)
        {
            var StudentDnevnik = _unitOfWork.StudentDnevniks.GetStudentDnevnik(id);
            if (StudentDnevnik == null) return HttpNotFound();

            var viewModel = new StudentDnevnikFormViewModel()
            {
                aktivnost = StudentDnevnik.aktivnost,
                linkovi = StudentDnevnik.linkovi,
                dodatno = StudentDnevnik.dodatno,
                komentar = StudentDnevnik.komentar
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(StudentDnevnikFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.StudentDnevniks = _unitOfWork.StudentDnevniks.GetStudentDnevniks();
                return View("StudentDnevnikFormViewModel", viewModel);
            }

            var studentDnevnik = _unitOfWork.StudentDnevniks.GetStudentDnevnik(viewModel.Id);
            studentDnevnik.aktivnost = viewModel.aktivnost;
            studentDnevnik.linkovi = viewModel.linkovi;
            studentDnevnik.dodatno = viewModel.dodatno;
            studentDnevnik.komentar = viewModel.komentar;
            _unitOfWork.Complete();

            return RedirectToAction("Index", "StudentDnevnik");
        }

        public ActionResult Delete(StudentDnevnik st)
        {
            _unitOfWork.StudentDnevniks.Delete(st.Id);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "StudentDnevnik");
        }

        //[Authorize(Roles = RoleName.MentorRoleName)]
        [HttpPost]
        public ActionResult ToggleStatus(int id)
        {
            var studentDnevnik = _unitOfWork.StudentDnevniks.GetStudentDnevnik(id);
            studentDnevnik.Odobreno = !studentDnevnik.Odobreno;
            _unitOfWork.Complete();
            return RedirectToAction("Index", "StudentDnevnik");
        }

        public ActionResult Details(int id)
        {
            var viewModel = new StudentDnevnikDetailViewModel()
            {
                studentDnevnik = _unitOfWork.StudentDnevniks.GetStudentDnevnik(id)
            };
            return View("Details", viewModel);
        }
    }
}