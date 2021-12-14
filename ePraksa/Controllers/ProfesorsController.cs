using System.Web.Mvc;
using PracticeManagement.Core;
using PracticeManagement.Core.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using PracticeManagement.Core.Models;


namespace PracticeManagement.Controllers
{
    // [Authorize]
    [Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.AdministratorRoleName)]
    public class ProfesorsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfesorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var Profesors = _unitOfWork.Profesors.GetProfesors();
            return View(Profesors);
        }

        //Details for admin
        public ActionResult Details(int id)
        {
            var viewModel = new ProfesorDetailViewModel
            {
                Profesor = _unitOfWork.Profesors.GetProfesor(id),
                UpcomingAppointments = _unitOfWork.Appointments.GetTodaysAppointments(id),
                Appointments = _unitOfWork.Appointments.GetAppointmentByProfesor(id),
            };
            return View(viewModel);
        }

        public ActionResult ProfesorProfile()
        {
            var userId = User.Identity.GetUserId();
            var viewModel = new ProfesorDetailViewModel
            {
                Profesor = _unitOfWork.Profesors.GetProfile(userId),
                Appointments = _unitOfWork.Appointments.GetUpcommingAppointments(userId),
            };
            return View(viewModel);
        }
        /// <summary>
        /// Ažurirati profesora može samo rola administrator aplikacije i fakulteta.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.AdministratorRoleName)]
        public ActionResult Edit(int id)
        {
            var Profesor = _unitOfWork.Profesors.GetProfesor(id);
            if (Profesor == null) return HttpNotFound();
            var viewModel = new ProfesorFormViewModel()
            {
                Id = Profesor.Id,
                Name = Profesor.Name,
                Phone = Profesor.Phone,
                Address = Profesor.Address,
                IsAvailable = Profesor.IsAvailable,
                Specialization = Profesor.SpecializationId,
                Specializations = _unitOfWork.Specializations.GetSpecializations()

            };
            return View(viewModel);
        }
        /// <summary>
        /// Ažurirati profesora može samo rola administrator aplikacije i fakulteta.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        //[Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.AdministratorRoleName)]
        [HttpPost]
        public ActionResult Edit(ProfesorFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Specializations = _unitOfWork.Specializations.GetSpecializations();
                return View(viewModel);
            }

            var ProfesorInDb = _unitOfWork.Profesors.GetProfesor(viewModel.Id);
            ProfesorInDb.Id = viewModel.Id;
            ProfesorInDb.Name = viewModel.Name;
            ProfesorInDb.Phone = viewModel.Phone;
            ProfesorInDb.Address = viewModel.Address;
            ProfesorInDb.IsAvailable = viewModel.IsAvailable;
            ProfesorInDb.SpecializationId = viewModel.Specialization;

            _unitOfWork.Complete();

            return RedirectToAction("Details", new { id = viewModel.Id });
        }


    }

}

