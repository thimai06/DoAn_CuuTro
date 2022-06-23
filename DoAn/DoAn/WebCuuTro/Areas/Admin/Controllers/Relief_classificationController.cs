using Models.DAO;
using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebCuuTro.Areas.Admin.Controllers
{
    public class Relief_classificationController : Controller
    {
        // GET: Admin/Relief_classification
        private DB_Relief db = new DB_Relief();

        public IEnumerable<Relief_classification> LisWheretAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Relief_classification> model = db.Relief_classification;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Description.Contains(keysearch));
            }
            return model.OrderBy(x => x.Description).ToPagedList(page, pagesize);
        }
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var pr = new Relief_classificationDao();
            var model = pr.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var pr = new Relief_classificationDao();
            var model = pr.LisWheretAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var cate = new Relief_classification();
            return View(cate);
        }

        [HttpPost]
        public ActionResult Create(Relief_classification enti_rc)
        {
            if (ModelState.IsValid)
            {
                var dao = new Relief_classificationDao();
                if (dao.Find(enti_rc.Description) != null)
                {
                    return RedirectToAction("Create", "Categorize");
                }
                String result = dao.Insert(enti_rc);
                if (!String.IsNullOrEmpty(result))
                {
                    return RedirectToAction("Index", "Categorize");

                }
                else
                {
                    ModelState.AddModelError("", "Tạo không thành công");
                }
            }

            return View();

        }

        [HttpGet]
        public ActionResult Edit(String id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relief_classification pe = db.Relief_classification.Find(id);
            if (pe == null)
            {
                return HttpNotFound();
            }

            return View(pe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Relief_classification enti_rc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enti_rc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enti_rc);
        }

    }
}