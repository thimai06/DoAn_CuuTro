using Common;

using Models.BaseRepository;
using Models.EF;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IIdentityServices
{
    public class IdentityService : IIdentityService
    {
        private readonly IRepository _repository;

        public IdentityService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Pesonal> Login(string username, string password)
        {
            return await _repository.FindAsnyc<Pesonal>(x => x.ID_user == username && x.password == password);
        }

        public async Task<Pesonal> FindByUser(string username)
        {
            return await _repository.FindAsnyc<Pesonal>(x => x.ID_user == username);
        }

        public async Task<ServiceResult<Pesonal>> Register(string username, string password)
        {
            try
            {
                if (await _repository.AnyAsync<Pesonal>(x => x.ID_user == username))
                {
                    return new ServiceResult<Pesonal>()
                    {
                        Data = null,
                        Successed = false,
                        Message = "Tài khoản đã tồn tại!"
                    };
                }
                var personal = new Pesonal()
                {
                    ID_user = username,
                    password = password,
                    Personal_name = username,
                    status = "1",
                    ID_type = "5",
                    Address = "Quảng trị",
                    Gender = "Nam",
                    Phone = "0123654789",
                    ID_card = Guid.NewGuid().ToString().Replace("-", String.Empty).Substring(0,11),
                };

                _repository.Add<Pesonal>(personal);

                await _repository.SaveChangesAsync();
                return new ServiceResult<Pesonal>()
                {
                    Data = null,
                    Successed = true,
                    Message = "Tài khoản đã tồn tại!"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<Pesonal>()
                {
                    Data = null,
                    Successed = false,
                    Message = ex.Message
                };
            }
        }
    }
}
