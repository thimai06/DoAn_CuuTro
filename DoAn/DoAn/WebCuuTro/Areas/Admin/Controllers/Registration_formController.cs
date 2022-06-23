using Models;
using Models.DAO;
using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebCuuTro.Areas.Admin.Models;

namespace WebCuuTro.Areas.Admin.Controllers
{
    public class Registration_formController : BaseController
    {
        // GET: Admin/Registration_form
        private DB_Relief db;

        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var pr = new Registration_formDao();
            var model = pr.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var pr = new Registration_formDao();
            var model = pr.LisWheretAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public ActionResult Details(int reliefId, string userId)
        {
            if (reliefId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pr = new Details_Registration_formDao();
            var model = pr.ListAll(reliefId, userId);
            if (model == null)
            {
                return HttpNotFound();
            }
            Pesonal pe = db.Pesonals.Find(userId);
            Relief re = db.Reliefs.Find(reliefId);

            ViewBag.UserName = pe.Personal_name;
            ViewBag.ReliefName = re.Title;

            return View(model);
        }



    }
}