using Common;
using Common.ViewModel;

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
            && curentDate <= x.End_date.Value && x.status != "0");
        }

        public async Task<List<Relief>> GetAllRelief(int pageInde, int pageSize)
        {
            var curentDate = DateTime.Now.Date;
            return await _repository.FindAllForPageAsnyc<Relief>(pageInde, pageSize, x => 
            x.Start_date.HasValue && x.End_date.HasValue && curentDate >= x.Start_date.Value
            && curentDate <= x.End_date.Value && x.status != "0");
        }

        public async Task<List<Relief>> FindAllRelief()
        {
            var curentDate = DateTime.Now.Date;
            return await _repository.FindAllAsnyc<Relief>(x =>
                x.Start_date.HasValue && x.End_date.HasValue && curentDate >= x.Start_date.Value
                && curentDate <= x.End_date.Value && x.status != "0");
        }

        public async Task<Relief> DetailRelief(int id)
        {
            return await _repository.FindAsnyc<Relief>(x => x.ID_relieft == id);
        }

        public async Task AddRelief(ReliefViewModel model)
        {
            var district = await _repository.FindAsnyc<District>(x => x.ID_district == model.DistrictId);
            var ward = await _repository.FindAsnyc<Ward>(x => x.ID_ward == model.WardId);

            var relief = new Relief()
            {
                ID_rc = model.RCId,
                ID_ward = model.WardId,
                Content = model.Content,
                Title = model.Title,
                Time_sent_post = DateTime.Now,
                Start_date = DateTime.Now,
                End_date = DateTime.Now.AddDays(20),
                status = "0",
                Description = model.Description,
                map = model.Thon + " - " + ward.Name_ward + " - " + district.Name_district,
                Proofs = new List<Proof>()
            };
            if (!string.IsNullOrEmpty(model.FilePath))
            {
                var proof = new Proof()
                {
                    Link = model.FilePath,
                    Type = "image",
                };
                relief.Proofs.Add(proof);
            }
            _repository.Add(relief);
            await _repository.SaveChangesAsync();
        }
    }
}
