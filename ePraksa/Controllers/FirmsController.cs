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
    [Authorize(Roles = RoleName.FirmaAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.MentorRoleName)]
    public class FirmsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FirmsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var firms = _unitOfWork.Firms.GetFirms();
            return View(firms);
        }

        public ActionResult Create()
        {
            var viewModel = new FirmFormViewModel
            {
                Heading = "New Firm",
                FirmTypes = _unitOfWork.FirmTypes.GetFirmTypes()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FirmFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.FirmTypes = _unitOfWork.FirmTypes.GetFirmTypes();
                return View(viewModel);

            }
            var firm = new Firm()
            {
                Name = viewModel.Name,
                Description = viewModel.Deacription,
                Address = viewModel.Address,
                TypeID = viewModel.TypeID,
                FirmAddress = new FirmAddress() {
                    Street = viewModel.Street,
                    PostalNumber = viewModel.PostalNumber,
                    City = viewModel.City

                }
            };

            _unitOfWork.Firms.Add(firm);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Firms");
        }

        public ActionResult Edit(int id)
        {
            var firm = _unitOfWork.Firms.GetFirm(id);
            var viewModel = new FirmFormViewModel()
            {
                Heading = "Edit Firm",
                Id = firm.Id,
                Name = firm.Name,
                Deacription = firm.Description,
                Address = firm.FirmAddress.Id,
                Street = firm.FirmAddress.Street,
                PostalNumber = firm.FirmAddress.PostalNumber,
                City = firm.FirmAddress.City,
                TypeID = firm.FirmType.Id,
                FirmTypes = _unitOfWork.FirmTypes.GetFirmTypes()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FirmFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.FirmTypes = _unitOfWork.FirmTypes.GetFirmTypes();
                return View(viewModel);
            }

            var firm = _unitOfWork.Firms.GetFirm(viewModel.Id);
            firm.Id = viewModel.Id;
            firm.Description = viewModel.Deacription;
            firm.Name = viewModel.Name;
            firm.Address = viewModel.Address;
            firm.FirmAddress = new FirmAddress()
            {
                Street = viewModel.Street,
                PostalNumber = viewModel.PostalNumber,
                City = viewModel.City

            };
            firm.TypeID = viewModel.TypeID;
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Firms");

        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var firm = _unitOfWork.Firms.GetFirm(id);
            _unitOfWork.Firms.Remove(firm);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Firms");
        }
    }
}