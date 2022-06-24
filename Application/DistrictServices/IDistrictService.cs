using Models.EF;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.DistrictServices
{
    public interface IDistrictService
    {
        Task CrawlDistrict();
        Task<List<District>> AllDistrict();
        Task<List<Ward>> AllWard(string id);
        Task<List<Relief_classification>> AllRC();
        Task<Ward> GetWard(string id);
        Task<District> GetDistrict(string id);
    }
}
