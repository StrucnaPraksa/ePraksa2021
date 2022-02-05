﻿using PracticeManagement.Core;
using PracticeManagement.Core.Helpers;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.ViewModel;
using System;
using System.Web.Mvc;

namespace PracticeManagement.Controllers
{
    public class PracticeBreaksController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PracticeBreaksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.MentorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult Index(int id)
        {
            var attendance = _unitOfWork.PracticeAttendances.GetPracticeAttendance(id);
            var breaks = _unitOfWork.PracticeBreaks.GetPracticeBreaks(id);

            var viewModel = new PracticeBreakIndexViewModel
            {
                PracticeAttendance = attendance,
                PracticeBreaks = breaks,
            };

            return View(viewModel);
        }

        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.MentorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult Details(int id)
        {
            var viewModel = new PracticeBreakDetailsViewModel
            {
                PracticeBreak = _unitOfWork.PracticeBreaks.GetPracticeBreak(id)
            };

            return View(viewModel);
        }

        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult Create(int practiceAttendanceId)
        {
            var practiceAttendance = _unitOfWork.PracticeAttendances.GetPracticeAttendance(practiceAttendanceId);

            var viewModel = new PracticeBreakDetailsViewModel
            {
                PracticeBreak = new PracticeBreak()
                {
                    PracticeAttendanceId = practiceAttendanceId,
                    PracticeAttendance = practiceAttendance,
                }
            };

            return View("Details", viewModel);
        }

        public ActionResult GoBack()
        {
            return RedirectToAction("Index", "PracticeAttendances");
        }

        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult Save(PracticeBreak practiceBreak)
        {
            if (practiceBreak.TimeStart > practiceBreak.TimeEnd)
                return new HttpStatusCodeResult(409);

            var breakRange = new Range<DateTime>(practiceBreak.TimeStart, practiceBreak.TimeEnd);

            var breaks = _unitOfWork.PracticeBreaks.GetPracticeBreaks(practiceBreak.PracticeAttendanceId);
            foreach (var @break in breaks)
            {
                var range = new Range<DateTime>(@break.TimeStart, @break.TimeEnd);

                if (range.IsOverlapped(breakRange))
                    return new HttpStatusCodeResult(409);
            }

            _unitOfWork.PracticeBreaks.UpdatePracticeBreak(practiceBreak);
            _unitOfWork.Complete();

            return RedirectToAction("Index", new { id = practiceBreak.PracticeAttendanceId });
        }

        [Authorize(Roles = RoleName.AdministratorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult Delete(int id, int practiceAttendanceId)
        {
            _unitOfWork.PracticeBreaks.DeletePracticeBreak(id);
            _unitOfWork.Complete();

            return RedirectToAction("Index", new { id = practiceAttendanceId });
        }
    }
}