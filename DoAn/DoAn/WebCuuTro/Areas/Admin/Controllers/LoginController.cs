using Models;
using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCuuTro.Areas.Admin.Models;

namespace WebCuuTro.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel login)
        {
            if (ModelState.IsValid) { 
                var user = new PersonalDao();
                var result = user.login(login.Username, login.Passwords);
                if (result == 0)
                {
                    //ModelState.AddModelError("", "Đăng nhập thành công");
                    Session.Add(Constants.USER_SESSION, login);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                
                        ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
               
                }
            }
            return View(login);
        }
    }
}