using Application.DistrictServices;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebCuuTro.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDistrictService _districtService;

        public HomeController(IDistrictService districtService)
        {
            _districtService = districtService;
        } 

        public async Task<ActionResult> Index()
        {
            await _districtService.CrawlDistrict();
            return View();
        }

        public ActionResult ViewAll()
        {
            return View();
        }

        public ActionResult DetailEvent()
        {
            return View();
        }

        public ActionResult Donation()
        {
            return View();
        }

        public ActionResult Reflect()
        {
            return View();
        }
        public ActionResult Regstration_form()
        {
            return View();
        }
    }
}