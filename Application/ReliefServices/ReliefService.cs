using Common;

using Models.BaseRepository;
using Models.EF;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ReliefServices
{
    public class ReliefService : IReliefService
    {
        private readonly IRepository _repository;

        public ReliefService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Pagination<Relief>> PaginationRelief(int pageInde, int pageSize)
        {
            var curentDate = DateTime.Now.Date;
            return await _repository.FindPageAsnyc<Relief>(pageInde, pageSize, x =>
            x.Start_date.HasValue && x.End_date.HasValue && curentDate >= x.Start_date.Value
            && curentDate <= x.End_date.Value);
        }

        public async Task<List<Relief>> GetAllRelief(int pageInde, int pageSize)
        {
            var curentDate = DateTime.Now.Date;
            return await _repository.FindAllForPageAsnyc<Relief>(pageInde, pageSize, x => 
            x.Start_date.HasValue && x.End_date.HasValue && curentDate >= x.Start_date.Value
            && curentDate <= x.End_date.Value);
        }

        public async Task<List<Relief>> FindAllRelief()
        {
            var curentDate = DateTime.Now.Date;
            return await _repository.FindAllAsnyc<Relief>(x =>
                x.Start_date.HasValue && x.End_date.HasValue && curentDate >= x.Start_date.Value
                && curentDate <= x.End_date.Value);
        }

        public async Task<Relief> DetailRelief(int id)
        {
            return await _repository.FindAsnyc<Relief>(x => x.ID_relieft == id);
        }

    }
}
