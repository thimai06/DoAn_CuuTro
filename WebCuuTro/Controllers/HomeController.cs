using Application.CategoryServices;
using Application.DistrictServices;
using Application.ProductServices;
using Application.ReceiptServices;
using Application.ReliefServices;

using Common.ViewModel.ReceiptViewModel;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

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
            return View(await _reliefService.DetailRelief(id));
        }

        public ActionResult Donation()
        {
            return View();
        }

        public ActionResult Reflect()
        {
            return View();
        }

        public async Task<ActionResult> Regstration_form(int id)
        {
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
    }
}