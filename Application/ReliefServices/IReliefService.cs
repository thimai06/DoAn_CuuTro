using Common;
using Models.EF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.ReliefServices
{
    public interface IReliefService
    {
        Task<Pagination<Relief>> PaginationRelief(int pageInde, int pageSize);
        Task<List<Relief>> GetAllRelief(int pageInde, int pageSize);
        Task<List<Relief>> FindAllRelief();
        Task<Relief> DetailRelief(int id);
    }
}
