using PracticeManagement.Core;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PracticeManagement.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager,
            ApplicationRoleManager roleManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            RoleManager = roleManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get { return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>(); }
            private set { _signInManager = value; }
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>(); }
            private set { _roleManager = value; }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,
                shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }

            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code,
                isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { Name = model.Name, UserName = model.Email, Email = model.Email, IsActive=true };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, RoleName.AdministratorRoleName);
                    UserManager.AddClaim(user.Id, new Claim(ClaimTypes.GivenName, model.Name));
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "Home");
                }

                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        //Profesor registration
        /// <summary>
        /// Registriraj novog profesora - anonimna prijava.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]        
        public ActionResult RegisterProfesor()
        {
            var viewModel = new ProfesorFormViewModel()
            {
                Specializations = _unitOfWork.Specializations.GetSpecializations()
                // Profesors = _ProfesorRepository.GetProfesor()
            };
            return View("ProfesorForm", viewModel);
        }
        /// <summary>
        /// Registriraj novog profesora i dodaj ga u rolu profesor
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.ProfesorRoleName + "," + RoleName.AdministratorRoleName)]
        public async Task<ActionResult> RegisterProfesor(ProfesorFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = viewModel.RegisterViewModel.Email,
                    Email = viewModel.RegisterViewModel.Email,
                    IsActive = true
                };
                var result = await UserManager.CreateAsync(user, viewModel.RegisterViewModel.Password);

                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, RoleName.ProfesorRoleName);
                    Profesor Profesor = new Profesor()
                    {
                        Name = viewModel.Name,
                        Phone = viewModel.Phone,
                        Address = viewModel.Address,
                        IsAvailable = true,
                        SpecializationId = viewModel.Specialization,
                        PhysicianId = user.Id
                    };
                    UserManager.AddClaim(user.Id, new Claim(ClaimTypes.GivenName, Profesor.Name));
                    //Mapper.Map<ProfesorFormViewModel, Profesor>(model, Profesor);
                    _unitOfWork.Profesors.Add(Profesor);
                    _unitOfWork.Complete();
                    return RedirectToAction("Index", "Profesors");
                }

                this.AddErrors(result);
            }

            viewModel.Specializations = _unitOfWork.Specializations.GetSpecializations();

            // If we got this far, something failed, redisplay form
            return View("ProfesorForm", viewModel);
        }





        //Student registration
        /// <summary>
        /// Registriraj novog studenta - anonimna prijava.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = RoleName.ProfesorRoleName + "," + RoleName.AdministratorRoleName)]
        public ActionResult RegisterStudent()
        {
            var viewModel = new StudentFormViewModel()
            {
                //Specializations = _unitOfWork.Specializations.GetSpecializations()
                //// Profesors = _ProfesorRepository.GetProfesor()
                YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies(),
                FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses(),
                Cities = _unitOfWork.Cities.GetCities(),
                Faculties = _unitOfWork.Faculties.GetFaculties()
            };
            return View("StudentForm", viewModel);
        }

        /// <summary>
        /// Registriraj novog studenta i dodaj ga u rolu student
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.ProfesorRoleName + "," + RoleName.AdministratorRoleName)]
        public async Task<ActionResult> RegisterStudent(StudentFormViewModel viewModel)
        {
                                                                               
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = viewModel.RegisterViewModel.Email,
                    Email = viewModel.RegisterViewModel.Email,
                    IsActive = true
                };
                var result = await UserManager.CreateAsync(user, viewModel.RegisterViewModel.Password);

                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, RoleName.StudentRoleName);

                    //if (!ModelState.IsValid)
                    //{
                    //    viewModel.YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies();
                    //    viewModel.FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses();
                    //    viewModel.Cities = _unitOfWork.Cities.GetCities();
                    //    viewModel.Faculties = _unitOfWork.Faculties.GetFaculties();
                    //    return View("StudentForm", viewModel);
                    //}
                    Student Student = new Student()
                    {
                        Firstname = viewModel.Firstname,
                        Lastname = viewModel.Lastname,
                        Email = viewModel.Email,
                        Active = viewModel.Active,
                        CityID = viewModel.City,
                        FacultyID = viewModel.Faculty,
                        FacultyCourseId = viewModel.FacultyCourse,
                        YearOfStudyID = viewModel.YearOfStudy,
                        CV = viewModel.CV
                    };
                    UserManager.AddClaim(user.Id, new Claim(ClaimTypes.GivenName, Student.Firstname));
                    _unitOfWork.Students.Add(Student);
                    _unitOfWork.Complete();
                    return RedirectToAction("Index", "Students");
                }

                this.AddErrors(result);
            }

            // viewModel.Specializations = _unitOfWork.Specializations.GetSpecializations();
            viewModel.Faculties = _unitOfWork.Faculties.GetFaculties();
            viewModel.Cities = _unitOfWork.Cities.GetCities();
            viewModel.FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses();
            viewModel.YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies();

            // If we got this far, something failed, redisplay form
            return View("StudentForm", viewModel);
        }

        //Mentor registration
        /// <summary>
        /// Registriraj novog Mentora - anonimna prijava.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = RoleName.ProfesorRoleName + "," + RoleName.AdministratorRoleName)]
        public ActionResult RegisterMentor()
        {
            var viewModel = new MentorFormViewModel()
            {
                //Specializations = _unitOfWork.Specializations.GetSpecializations()
                //// Profesors = _ProfesorRepository.GetProfesor()
                Firms = _unitOfWork.Firms.GetFirms()
               
            };
            return View("MentorForm", viewModel);
        }

        /// <summary>
        /// Registriraj novog Mentora i dodaj ga u rolu Mentor
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.ProfesorRoleName + "," + RoleName.AdministratorRoleName)]
        public async Task<ActionResult> RegisterMentor(MentorFormViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = viewModel.RegisterViewModel.Email,
                    Email = viewModel.RegisterViewModel.Email,
                    IsActive = true
                };
                var result = await UserManager.CreateAsync(user, viewModel.RegisterViewModel.Password);

                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, RoleName.MentorRoleName);

                    //if (!ModelState.IsValid)
                    //{
                    //    viewModel.YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies();
                    //    viewModel.FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses();
                    //    viewModel.Cities = _unitOfWork.Cities.GetCities();
                    //    viewModel.Faculties = _unitOfWork.Faculties.GetFaculties();
                    //    return View("MentorForm", viewModel);
                    //}
                    Mentor Mentor = new Mentor()
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
                    UserManager.AddClaim(user.Id, new Claim(ClaimTypes.GivenName, Mentor.FirstName));
                    _unitOfWork.Mentors.Add(Mentor);
                    _unitOfWork.Complete();
                    return RedirectToAction("Index", "Mentors");
                }

                this.AddErrors(result);
            }

            // viewModel.Specializations = _unitOfWork.Specializations.GetSpecializations();
            viewModel.Firms = _unitOfWork.Firms.GetFirms();
            // If we got this far, something failed, redisplay form
            return View("MentorForm", viewModel);
        }



        //Person registration
        [AllowAnonymous]
        public ActionResult RegisterPerson()
        {
            var viewModel = new PersonFormViewModel()
            {
                Faculties = _unitOfWork.Faculties.GetFaculties()
              
            };
            return View("PersonForm", viewModel);
        }

        /// <summary>
        /// Registriraj novu osobu i dodaj joj rolu Student. 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.StudentRoleName + "," + RoleName.AdministratorRoleName)]
        public async Task<ActionResult> RegisterPerson(PersonFormViewModel viewModel)
        {
            if (ModelState.IsValid) //TODO: ispravi ovo!!!
            {
                var user = new ApplicationUser()
                {
                    UserName = viewModel.RegisterViewModel.Email,
                    Email = viewModel.RegisterViewModel.Email,
                    IsActive = true
                };
                var result = await UserManager.CreateAsync(user, viewModel.RegisterViewModel.Password);

                if (result.Succeeded)
                {

                    UserManager.AddToRole(user.Id, RoleName.StudentRoleName);

                    //int aaa = viewModel.Faculty;
                    Person Person = new Person()
                    {
                        Name = viewModel.Name,
                        Phone=viewModel.Phone,
                        Address=viewModel.Address,                        
                        FacultyId = viewModel.Faculty,
                        //PhysicianId = user.Id
                    };
                    UserManager.AddClaim(user.Id, new Claim(ClaimTypes.GivenName, Person.Name));
                    //Mapper.Map<ProfesorFormViewModel, Profesor>(model, Profesor);
                    _unitOfWork.Persons.Add(Person);
                    _unitOfWork.Complete();
                    return RedirectToAction("Index", "Persons");
                }

                this.AddErrors(result);
            }

            viewModel.Faculties = _unitOfWork.Faculties.GetFaculties();

            // If we got this far, something failed, redisplay form
            return View("PersonForm", viewModel);
        }




        //list users
        public ActionResult Index()
        {
            var usersWithRoles = _unitOfWork.Users.GetUsers();
            return View(usersWithRoles);
        }


        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = _unitOfWork.Users.GetUser(id);
            if (user == null)
            {
                return HttpNotFound();
            }


            var viewModel = new UserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                IsActive = user.IsActive,
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel editUser)
        {
            if (ModelState.IsValid)

            {
                var user = _unitOfWork.Users.GetUser(editUser.Id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                //user.UserName = editUser.Email;
                // user.Id = editUser.Id;
                user.Email = editUser.Email;
                user.IsActive = editUser.IsActive;
                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something failed.");
            return View(editUser);
        }



        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }

            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);		
                // await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                // return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }

            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }

            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider,
                Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }

            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose })
                .ToList();
            return View(new SendCodeViewModel
            {
                Providers = factorOptions,
                ReturnUrl = returnUrl,
                RememberMe = rememberMe
            });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }

            return RedirectToAction("VerifyCode",
                new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation",
                        new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model,
            string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }

                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }

                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers

        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }

                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }

        #endregion
    }
}