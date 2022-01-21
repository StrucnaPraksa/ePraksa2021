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

        [Authorize(Roles = RoleName.MentorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult Index(int praksaId)
        {
            var StudentDnevnik = _unitOfWork.StudentDnevniks.GetStudentDnevniks(praksaId);
            var model = new StudentDnevnikIndexViewModel{ StudentDnevniks = StudentDnevnik, praksaId = praksaId };
            return View(model);
        }

        [Authorize(Roles = RoleName.StudentRoleName)]
        public ActionResult Create(int praksaId)
        {
            var viewModel = new StudentDnevnikFormViewModel
            {
                StudentDnevniks = _unitOfWork.StudentDnevniks.GetStudentDnevniks(praksaId),
                Heading = "New Student",
                studentPraksaId = praksaId,
            };
            return View("StudentDnevnikForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentDnevnikFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.StudentDnevniks = _unitOfWork.StudentDnevniks.GetStudentDnevniks(viewModel.studentPraksaId);
                return View("StudentDnevnikFormViewModel", viewModel);

            }

            var studentDnevnik = new StudentDnevnik
            {
                studentPraksaId = viewModel.studentPraksaId,
                datum = System.DateTime.Now,
                aktivnost = viewModel.aktivnost,
                linkovi = viewModel.linkovi,
                dodatno = viewModel.dodatno,
                komentar = viewModel.komentar
            };

            _unitOfWork.StudentDnevniks.Add(studentDnevnik);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "StudentDnevnik", new { praksaId = viewModel.studentPraksaId });
        }

        [Authorize(Roles = RoleName.MentorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult Edit(int id)
        {
            var StudentDnevnik = _unitOfWork.StudentDnevniks.GetStudentDnevnik(id);
            if (StudentDnevnik == null) return HttpNotFound();

            var viewModel = new StudentDnevnikFormViewModel()
            {
                studentPraksaId = StudentDnevnik.studentPraksaId,
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
                viewModel.StudentDnevniks = _unitOfWork.StudentDnevniks.GetStudentDnevniks(viewModel.studentPraksaId);
                return View("StudentDnevnikFormViewModel", viewModel);
            }

            var studentDnevnik = _unitOfWork.StudentDnevniks.GetStudentDnevnik(viewModel.Id);
            studentDnevnik.aktivnost = viewModel.aktivnost;
            studentDnevnik.linkovi = viewModel.linkovi;
            studentDnevnik.dodatno = viewModel.dodatno;
            studentDnevnik.komentar = viewModel.komentar;
            _unitOfWork.Complete();

            return RedirectToAction("Index", "StudentDnevnik", new { praksaId = viewModel.studentPraksaId });
        }

        [Authorize(Roles = RoleName.StudentRoleName)]
        public ActionResult Delete(StudentDnevnik st)
        {
            _unitOfWork.StudentDnevniks.Delete(st.Id);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "StudentDnevnik", new { praksaId = st.studentPraksaId });
        }

        [Authorize(Roles = RoleName.MentorRoleName)]
        [HttpPost]
        public ActionResult ToggleStatus(int id)
        {
            var studentDnevnik = _unitOfWork.StudentDnevniks.GetStudentDnevnik(id);
            studentDnevnik.Odobreno = !studentDnevnik.Odobreno;
            _unitOfWork.Complete();
            return RedirectToAction("Index", "StudentDnevnik", new { praksaId = id });
        }

        [Authorize(Roles = RoleName.MentorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult Details(int id)
        {
            var viewModel = new StudentDnevnikDetailViewModel()
            {
                studentDnevnik = _unitOfWork.StudentDnevniks.GetStudentDnevnik(id),
                praksaId = id
   
            };
            return View("Details", viewModel);
        }
    }
}