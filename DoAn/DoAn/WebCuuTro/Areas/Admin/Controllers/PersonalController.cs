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
    public class PersonalController : BaseController
    {
        private DB_Relief db = new DB_Relief() ;

        
        public IEnumerable<Pesonal> LisWheretAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Pesonal> model = db.Pesonals;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Personal_name.Contains(keysearch) || x.Address.Contains(keysearch));
            }
            return model.OrderBy(x => x.Personal_name).ToPagedList(page, pagesize);
        }
        public ActionResult Index(int page = 1, int pagesize = 5, string error = "")
        {
            var pr = new PersonalDao();
            var model = pr.ListAll();
            if (error == "error")
            {
                ModelState.AddModelError("", "Tài khoản hiện không xóa được?");
            }
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var pr = new PersonalDao();
            var model = pr.LisWheretAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var person = new Pesonal();
            return View(person);
        }

        [HttpPost]
        public ActionResult Create(Pesonal enti_pe)
        {
            //var person = new PersonalDao();
            //String result = person.Insert(enti_pe);
            //if (!string.IsNullOrEmpty(result))
            //{
            //    return RedirectToAction("Index", "Personal");
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Tạo không thành công");
            //    return View();
            //}
            if (ModelState.IsValid)
            {
                var dao = new PersonalDao();
                if(dao.Find(enti_pe.ID_user)!= null)
                {
                    return RedirectToAction("Create", "User");
                }
                String result = dao.Insert(enti_pe);
                if (!String.IsNullOrEmpty(result))
                {
                    return RedirectToAction("Index", "Personal");

                }
                else
                {
                    ModelState.AddModelError("", "Tạo không thành công");
                }
            }

            return View();

        }
        
        [HttpGet]
        public ActionResult Edit(string userId)
        {
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pesonal pe = db.Pesonals.Find(userId);
            if (pe == null)
            {
                return HttpNotFound();
            }
            
            return View(pe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pesonal enti_pe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enti_pe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }           
            return View(enti_pe);
        }
            
        public ActionResult Details(string userId)
        {
            if (userId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pesonal pe = db.Pesonals.Find(userId);
            if (pe == null)
            {
                return HttpNotFound();
            }
            return View(pe);
        }

        public ActionResult Delete(string userId)
        {
            bool dao = new PersonalDao().Detele(userId);
            if (!dao)
            {
                return RedirectToAction("Index", new{ error = "error"});
            }
            return RedirectToAction("Index");
        }
    }
}

