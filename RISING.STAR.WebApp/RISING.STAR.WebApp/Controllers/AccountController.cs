using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;


using RISING.STAR.Business.PatientBusiness;
using RISING.STAR.WebApp.Models;
using RISING.STAR.DAL;
using RISING.STAR.Utils.Password;
using System.Collections.Generic;

namespace RISING.STAR.WebApp.Controllers
{
    

    public class AccountController : Controller
    {

        private RISINGSTAREntities db = new RISINGSTAREntities();

        public AccountController()
        {
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {

            //var locBuss = new LocationBusiness();

            var lvm = new LoginViewModel();
            //var locs  = locBuss.RetrieveLocations().Select(x =>
            //                new SelectListItem
            //                {
            //                    Value = x.LocationGuid.ToString(),
            //                    Text = x.Description
            //                }
            //    );

            ////lvm.Locations = locs;
            
            ViewBag.ReturnUrl = returnUrl;
            return View(lvm);
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //var mypass = PasswordCreation.CreateHash("Brian3##");

            User user = db.Users.Where(x => x.Login == model.Login).FirstOrDefault();
            if(user == null)
            {
                ModelState.AddModelError("", "Invalid login.");
                return View(model);
            }

            if (!user.Active)
            {
                ModelState.AddModelError("", "Inactive user.");
                return View(model);
            }

            if (!PasswordCreation.ValidatePassword(model.Password, user.PasswordHash))
            {
                ModelState.AddModelError("", "Invalid password.");
                return View(model);
            }

            string roles = AllRoles(user, 0);
            string rolesDisplay = AllRoles(user, 1);
            
            Session["PatientList"] = this.GetPatients();

            Session["UserID"] = user.Guid;
            Session["UserRoles"] = roles;
            Session["UserRolesDisplay"] = rolesDisplay;
            Session["UserDados"] = user;
            return RedirectToAction("Index", "Dashboard");

        }

        private IEnumerable<SelectListItem> GetPatients()
        {
            PatientBusiness patientBuss = new PatientBusiness();
            var patientList = patientBuss.RetrieveAllPatients();

            var dropdownData = patientList
               .Select(d => new SelectListItem
               {
                   Text = d.Name,
                   Value = d.Id.ToString()
               })
               .ToList();

            return dropdownData;
        }

        protected string AllRoles(User user, int tipo)
        {
            string roles = string.Empty;
            string rolesDysplay = string.Empty;

            foreach (Role role in user.Roles)
            {
                if (roles.Equals(string.Empty))
                {
                    roles = role.RoleDescription;
                    rolesDysplay = role.DescriptionDisplay;
                }
                else
                {
                    roles = roles + " - " + role.RoleDescription;
                    rolesDysplay = rolesDysplay + " - " + role.DescriptionDisplay;
                }
            }
            if (tipo == 0)
                return roles;
            else
                return rolesDysplay;

        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
       
        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
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
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }
              
        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.RemoveAll();
            return RedirectToAction("Login", "Account", new { area = "" });
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
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
            return RedirectToAction("Index", "Dashboard");
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