using Application.IIdentityServices;

using Models;
using Models.DAO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using WebCuuTro.Areas.Admin.Models;

namespace WebCuuTro.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IIdentityService _identityService;

        public LoginController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var data = await _identityService.Login(login.Username, login.Passwords);

                if (data != null)
                {
                    var roles = string.Empty;
                    if (data.Role_Type != null)
                    {
                        roles = data.Role_Type.Name_role;
                    }
                    SetRoles(login.Username, roles);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {

                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");

                }
            }
            return View(login);
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
    }
}