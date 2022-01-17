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
    public class PollMentorAnswersController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public PollMentorAnswersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var PollMentorAnswers = _unitOfWork.PollMentorAnswers.GetPollMentorAnswers();
            return View(PollMentorAnswers);
        }


        
        //[Authorize(Roles = RoleName.FirmaAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName)]
       // [Authorize(Roles = RoleName.AdministratorRoleName)]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var PollMentorAnswers = _unitOfWork.PollMentorAnswers.GetPollMentorAnswer(id);
            _unitOfWork.PollMentorAnswers.Remove(PollMentorAnswers);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "PollMentorAnswers");
        }

       // [Authorize(Roles = RoleName.AdministratorRoleName)]
        [HttpPost]
        public ActionResult ToggleStatus(int id)
        {
            var PollMentorAnswers = _unitOfWork.PollMentorAnswers.GetPollMentorAnswer(id);
            PollMentorAnswers.Active = !PollMentorAnswers.Active;
            _unitOfWork.Complete();
            return RedirectToAction("Index", "PollMentorAnswers");
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