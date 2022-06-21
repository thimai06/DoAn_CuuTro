using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCuuTro.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session[Constants.USER_SESSION] == null)
                return RedirectToAction("Index", "Login");
            return View();
        }
        public ActionResult Logout()
        {
            Session[Constants.USER_SESSION] = null;
                return RedirectToAction("Index", "Login");
            
        }
    }
}