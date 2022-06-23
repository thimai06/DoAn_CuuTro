using Models;
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
using WebCuuTro.Areas.Admin.Models;

namespace WebCuuTro.Areas.Admin.Controllers
{
    public class ReliefController : BaseController
    {
        // GET: Admin/Relief
        private DB_Relief db= new DB_Relief();
        public IEnumerable<Relief> LisWheretAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Relief> model = db.Reliefs;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Title.Contains(keysearch) );
            }
            return model.OrderBy(x => x.Title).ToPagedList(page, pagesize);
        }
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var pr = new ReliefDao();
            var model = pr.ListAll();

            return View(model.ToPagedList(page, pagesize));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var pr = new ReliefDao();
            var model = pr.LisWheretAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relief re = db.Reliefs.Find(id);
            if (re == null)
            {
                return HttpNotFound();
            }
     
            return View(re);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDSP,TenSP,DonGia,SoLuong,MoTa,LoaiSP_ID")] Relief re)
        {
            if (ModelState.IsValid)
            {
                db.Entry(re).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
         
            }
            //ViewBag.LoaiSP_ID = new SelectList(db.LoaiSPs, "IDLSP", "TenLoai", sanPham.LoaiSP_ID);
            return View(re);
        }
        public ActionResult Details(int id)
        {
            //return View();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var re = db.Reliefs.Where(x => x.ID_relieft == id);
            //Relief re = db.Reliefs.Find(id);
            if (re == null)
            {
                return HttpNotFound();
            }
            return View(re);
        }
        public ActionResult Delete(int id)
        {
            Boolean dao = new ReliefDao().Detele(id);

            return RedirectToAction("Index");
        }

    }
}