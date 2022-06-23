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
    public class CategorizeController : BaseController
    {
        // GET: Admin/Categorize
        private DB_Relief db = new DB_Relief();
        
        public IEnumerable<categorize> LisWheretAll(string keysearch, int page, int pagesize)
        {
            IQueryable<categorize> model = db.categorizes;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Name_cate.Contains(keysearch) );
            }
            return model.OrderBy(x => x.Name_cate).ToPagedList(page, pagesize);
        }
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var pr = new CategorizeDao();
            var model = pr.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var pr = new CategorizeDao();
            var model = pr.LisWheretAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var cate = new categorize();
            return View(cate);
        }

        [HttpPost]
        public ActionResult Create(categorize enti_ca)
        {            
            if (ModelState.IsValid)
            {
                var dao = new CategorizeDao();
                if (dao.Find(enti_ca.ID_cate) != null)
                {
                    return RedirectToAction("Create", "Categorize");
                }
                String result = dao.Insert(enti_ca);
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
            categorize pe = db.categorizes.Find(id);
            if (pe == null)
            {
                return HttpNotFound();
            }

            return View(pe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(categorize enti_ca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enti_ca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enti_ca);
        }


    }
}