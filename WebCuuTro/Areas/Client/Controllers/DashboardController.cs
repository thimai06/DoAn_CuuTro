using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCuuTro.Areas.Client.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Client/Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View();
        }

        public ActionResult DetailEvent()
        {
            return View();
        }

        public ActionResult Donation()
        {
            return View();
        }

        public ActionResult Reflect()
        {
            return View();
        }
        public ActionResult Regstration_form()
        {
            return View();
        }
    }
}