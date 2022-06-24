using Application.IIdentityServices;

using Common.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace WebCuuTro.Controllers
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = await _identityService.Login(model.Username, model.Passwords);
                if (data == null)
                {
                    ModelState.AddModelError("", @"Sai tài khoản hoặc mật khẩu");
                    return View(model);
                }
                var roles = string.Empty;
                if(data.Role_Type != null)
                {
                    roles = data.Role_Type.Name_role;
                }
                SetRoles(model.Username, roles);
                if(data.Role_Type != null && data.Role_Type.Name_role == "Root")
                {
                    return RedirectToAction("Admin", "Admin");
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if(model.Passwords != model.ConfirmPasswords)
            {
                ModelState.AddModelError("", @"Mật khẩu xác nhận không khớp");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                var data = await _identityService.Register(model.Username, model.Passwords);
                if (!data.Successed)
                {
                    ModelState.AddModelError("", @"" + data.Message);
                    return View(model);
                }
                return RedirectToAction("Login");
            }
            return View(model);

        }

        void SetRoles(string userName, string roles)
        {
            FormsAuthentication.Initialize();
            var ticket = new FormsAuthenticationTicket(1, userName,
                                                        DateTime.Now, //time begin
                                                        DateTime.Now.AddDays(3), //timeout
                                                        false, roles,
                                                        FormsAuthentication.FormsCookiePath);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            if (ticket.IsPersistent)
                cookie.Expires = ticket.Expiration;

            Response.Cookies.Add(cookie);
        }

        string GetUserNameFromCookie()
        {
            try
            {
                string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
                HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
                if (authCookie == null) return null;
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
                return ticket.Name; //You have the UserName!
            }
            catch
            {
                return null;
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public PartialViewResult HeaderPartial()
        {
            ViewBag.userName = GetUserNameFromCookie();
            return PartialView();
        }
    }
}