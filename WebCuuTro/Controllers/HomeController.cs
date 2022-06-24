using Application.CategoryServices;
using Application.DistrictServices;
using Application.ProductServices;
using Application.ReceiptServices;
using Application.ReliefServices;

using Common.ViewModel;
using Common.ViewModel.ReceiptViewModel;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebCuuTro.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDistrictService _districtService;
        private readonly IReliefService _reliefService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IReceiptService _receiptService;

        public HomeController(IDistrictService districtService, IReliefService reliefService, 
            ICategoryService categoryService, IProductService productService, IReceiptService receiptService)
        {
            _districtService = districtService;
            _reliefService = reliefService;
            _categoryService = categoryService;
            _productService = productService;
            _receiptService = receiptService;
        } 

        public async Task<ActionResult> Index()
        {
            return View(await _reliefService.GetAllRelief(1, 4));
        }

        public async Task<ActionResult> ViewAll()
        {
            return View(await _reliefService.FindAllRelief());
        }

        public async Task<ActionResult> DetailEvent(int id)
        {
            var detail = await _reliefService.DetailRelief(id);
            ViewBag.ward = await _districtService.GetWard(detail.ID_ward);
            return View(detail);
        }

        public ActionResult Donation()
        {
            return View();
        }

        public async Task<ActionResult> Reflect()
        {
            if (string.IsNullOrEmpty(GetUserNameFromCookie()))
            {
                return RedirectToAction("Login","Identity");
            }
            ViewBag.District = await _districtService.AllDistrict();
            ViewBag.RC = await _districtService.AllRC();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Reflect(ReliefViewModel model, HttpPostedFileBase fileImage)
        {
            if (ModelState.IsValid)
            {
                ViewBag.result = 1;
                await _reliefService.AddRelief(model);
                return View();
            }
            ViewBag.District = await _districtService.AllDistrict();
            ViewBag.RC = await _districtService.AllRC();
            ViewBag.result = 0;
            return View(model);
        }

        public async Task<ActionResult> ListRelief()
        {
            return View(await _reliefService.FindAllRelief());
        }

        public async Task<ActionResult> ListReceipt(int id)
        {
            ViewBag.relief = await _reliefService.DetailRelief(id);
            return View(await _receiptService.ListReceipt(id));
        }

        public async Task<ActionResult> Regstration_form(int id)
        {
            if (string.IsNullOrEmpty(GetUserNameFromCookie()))
            {
                return RedirectToAction("Login", "Identity");
            }

            ViewBag.categories = await _categoryService.AllCategory();

            return View(await _reliefService.DetailRelief(id));
        }


        [HttpPost]
        public async Task<ActionResult> Regstration_form(ReceiptRequest receipt, List<ReceiptDetailRequest> detail)
        {
            ViewBag.categories = await _categoryService.AllCategory();
            if(detail == null || !detail.Any())
            {
                ViewBag.Result = 0;
                return View(await _reliefService.DetailRelief(receipt.RelieftId));
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Result = 0;
                return View(await _reliefService.DetailRelief(receipt.RelieftId));
            }
            ViewBag.Result = 1;
            await _receiptService.ReliefReceipt(receipt, detail);
            ViewBag.Result = 1;
            return View(await _reliefService.DetailRelief(receipt.RelieftId));
        }

        public async Task<PartialViewResult> OptionProduct(string categoryId)
        {
            return PartialView(await _productService.AllProduct(categoryId));
        }

        public async Task<PartialViewResult> OptionWard(string id)
        {
            return PartialView(await _districtService.AllWard(id));
        }

        string GetUserNameFromCookie()
        {
            try
            {
                string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
                HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
                if (authCookie == null) return null;
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
                return ticket.Name; //You have the UserName!
            }
            catch
            {
                return null;
            }
        }
    }
}