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
    public class ProductController : Controller
    {
        // GET: Admin/Product
        private DB_Relief db = new DB_Relief();

        public IEnumerable<Product> LisWheretAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Name_product.Contains(keysearch));
            }
            return model.OrderBy(x => x.Name_product).ToPagedList(page, pagesize);
        }
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var pr = new ProductDAO();
            var model = pr.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var pr = new ProductDAO();
            var model = pr.LisWheretAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ID_cate = new SelectList(db.categorizes, "ID_cate", "Name_cate");
            var pro = new Product();
            return View(pro);
        }

        [HttpPost]
        public ActionResult Create(Product enti_pro)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDAO();
                if (dao.Find(enti_pro.ID_product) != null)
                {
                    return RedirectToAction("Create", "Product");
                }
                String result = dao.Insert(enti_pro);
                if (!String.IsNullOrEmpty(result))
                {
                    return RedirectToAction("Index", "Product");

                }
                else
                {
                    ModelState.AddModelError("", "Tạo không thành công");
                }
            }
            ViewBag.ID_cate = new SelectList(db.categorizes, "ID_cate", "Name_cate", enti_pro.ID_cate);
            return View();

        }

        [HttpGet]
        public ActionResult Edit(String id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product pro = db.Products.Find(id);
            if (pro == null)
            {
                return HttpNotFound();
            }

            return View(pro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product enti_pro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enti_pro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enti_pro);
        }

    }
}