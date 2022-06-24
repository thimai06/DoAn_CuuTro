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
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var pr = new ReceiptDao();
            var model = pr.LisWheretAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SyncUpData();
            return View();
        }

        public void SyncUpData ()
        {
            var reDao = new ReliefDao();
            var prDao = new ProductDAO();
            var catDao = new ProductDAO();

            ViewBag.ID_relieft = new SelectList(reDao.ListAll(), "ID_relieft", "Title");
            ViewBag.Products = new SelectList(prDao.ListAll(), "ID_product", "Name_product");
            ViewBag.Categories = new SelectList(catDao.ListAll(), "ID_cate", "Name_cate");
        }

        [HttpPost]
        public ActionResult Create(ReceiptModel enti_re)
        {
            if (ModelState.IsValid)
            {
                var dao = new ReceiptDao();
                if (dao.Find( enti_re.ID_receipt) != null)
                {
                    return RedirectToAction("Create", "User");
                }
                var receiptTemp = new Receipt();
                receiptTemp.ID_relieft = enti_re.ID_relieft;
                receiptTemp.Date = enti_re.Date;
                receiptTemp.ID_user = enti_re.ID_user;
                receiptTemp.Details_receipt = enti_re.Details_receipt;
                receiptTemp.Nguoitang = enti_re.Nguoitang;
                
                dao.Insert(receiptTemp);

                return RedirectToAction("Index", "Receipt");
            }
            SyncUpData();
            //ViewBag.ID_relieft = new SelectList(db.Reliefs, "ID_relieft", "Title", enti_re.ID_relieft);                 
            return View();

        }

        public ActionResult Details(int reliefId, string user)
        {
            if (reliefId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var pr = new Details_ReceiptDao();
            var model = pr.ListAll(reliefId, user);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

     


    }
}