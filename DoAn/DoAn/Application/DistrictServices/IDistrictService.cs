using System.Threading.Tasks;

namespace Application.DistrictServices
{
    public interface IDistrictService
    {
        Task CrawlDistrict();
    }
}
