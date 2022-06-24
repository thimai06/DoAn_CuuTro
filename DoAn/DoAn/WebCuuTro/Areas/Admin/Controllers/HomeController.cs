using Models;
using Models.DAO;
using System;
using System.Collections.Generic;
using System.Data;
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

        [HttpPost]
        public JsonResult LoadDataChart()
        {
            var reliefDao = new ReliefDao();
            var dataChart  = reliefDao.GetReportData();

            List<object> iData = new List<object>();
            //Creating sample data  
            DataTable dt = new DataTable();
            dt.Columns.Add("Month", System.Type.GetType("System.String"));
            dt.Columns.Add("Count", System.Type.GetType("System.Int32"));

            
            foreach(var it in dataChart)
            {
                DataRow dr = dt.NewRow();
                dr["Month"] = "Tháng "+ it.month;
                dr["Count"] = it.count;
                dt.Rows.Add(dr);
            }
            //Looping and extracting each DataColumn to List<Object>  
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            return Json(iData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Logout()
        {
            Session[Constants.USER_SESSION] = null;
                return RedirectToAction("Index", "Login");
            
        }
    }
}