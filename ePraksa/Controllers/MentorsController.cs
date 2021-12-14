using PracticeManagement.Core;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeManagement.Controllers
{
    [Authorize(Roles = RoleName.FirmaAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName)]
    public class MentorsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
     
        public MentorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var mentors = _unitOfWork.Mentors.GetMentors();
            return View(mentors);
        }

        public ActionResult Create()
        {
            var viewModel = new MentorFormViewModel
            {
                Heading = "New Mentor",
                Firms = _unitOfWork.Firms.GetFirms()
            };
            return View(viewModel);
        }
        //[Authorize(Roles = RoleName.FirmaAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MentorFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Firms = _unitOfWork.Firms.GetFirms();
                return View(viewModel);

            }
            var mentor = new Mentor()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Title = viewModel.Title,
                Occupation = viewModel.Occupation,
                Email = viewModel.Email,
                Address = viewModel.Address,
                FirmId = viewModel.FirmId,
                YearsOfExperience = viewModel.YearsOfExperience,
                Competence = viewModel.Competence,
                CV = viewModel.CV,
                Activated = true
            };

            _unitOfWork.Mentors.Add(mentor);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Mentors");
        }
        //[Authorize(Roles = RoleName.FirmaAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName)]
        public ActionResult Edit(int id)
        {
            var mentor = _unitOfWork.Mentors.GetMentor(id);
            var viewModel = new MentorFormViewModel()
            {
                Heading = "Edit Mentor",
                Id = mentor.Id,
                FirstName = mentor.FirstName,
                LastName = mentor.LastName,
                Title = mentor.Title,
                Occupation = mentor.Occupation,
                Email = mentor.Email,
                Address = mentor.Address,
                FirmId = mentor.FirmId,
                YearsOfExperience = mentor.YearsOfExperience,
                Competence = mentor.Competence,
                CV = mentor.CV,
                Firms = _unitOfWork.Firms.GetFirms()
            };
            return View(viewModel);
        }
        //[Authorize(Roles = RoleName.FirmaAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MentorFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Firms = _unitOfWork.Firms.GetFirms();
                return View(viewModel);
            }

            var mentor = _unitOfWork.Mentors.GetMentor(viewModel.Id);
            mentor.Id = viewModel.Id;
            mentor.FirstName = viewModel.FirstName;
            mentor.LastName = viewModel.LastName;
            mentor.Title = viewModel.Title;
            mentor.Occupation = viewModel.Occupation;
            mentor.Email = viewModel.Email;
            mentor.Address = viewModel.Address;
            mentor.YearsOfExperience = viewModel.YearsOfExperience;
            mentor.Competence = viewModel.Competence;
            mentor.CV = viewModel.CV;
            mentor.FirmId = viewModel.FirmId;
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Mentors");

        }

        //[Authorize(Roles = RoleName.FirmaAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName)]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var mentor = _unitOfWork.Mentors.GetMentor(id);
            _unitOfWork.Mentors.Remove(mentor);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Mentors");
        }

        [HttpPost]
        public ActionResult ToggleStatus(int id)
        {
            var mentor = _unitOfWork.Mentors.GetMentor(id);
            mentor.Activated = !mentor.Activated;
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Mentors");
        }
    }
}