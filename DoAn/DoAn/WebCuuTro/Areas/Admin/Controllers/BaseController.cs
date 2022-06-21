using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebCuuTro.Areas.Admin.Models;

namespace WebCuuTro.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuted(ActionExecutedContext filtercontext)
        {
            var session = (LoginModel)Session[Constants.USER_SESSION];
            if (session == null)
            {
                filtercontext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    action = "Index",
                    controller = "Login",
                    area = "Admin"
                }));
            }

            base.OnActionExecuted(filtercontext);
        }
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }

            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}