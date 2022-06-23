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
    public class ReceiptController : BaseController
    {

        // GET: Admin/Receipt

        private DB_Relief db;
        
        public IEnumerable<Receipt> LisWheretAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Receipt> model = db.Receipts;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Pesonal.Personal_name.Contains(keysearch) || x.Relief.Title.Contains(keysearch));
            }
            return model.OrderBy(x => x.Pesonal.Personal_name).ToPagedList(page, pagesize);
        }
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var re = new ReceiptDao();
            var model = re.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var pr = new ReceiptDao();
            var model = pr.LisWheretAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receipt pe = db.Receipts.Find(id);
            if (pe == null)
            {
                return HttpNotFound();
            }
            return View(pe);
        }
    }
}