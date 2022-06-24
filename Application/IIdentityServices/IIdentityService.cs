using Common;

using Models.EF;

using System.Threading.Tasks;

namespace Application.IIdentityServices
{
    public interface IIdentityService
    {
        Task<Pesonal> Login(string username, string password);
        Task<Pesonal> FindByUser(string username);
        Task<ServiceResult<Pesonal>> Register(string username, string password);
    }
}
