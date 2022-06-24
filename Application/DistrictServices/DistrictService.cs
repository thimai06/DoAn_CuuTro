using Common;
using Common.ViewModel;

using Models.BaseRepository;
using Models.EF;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.DistrictServices
{
    public class DistrictService : IDistrictService
    {
        private readonly IRepository _repository;

        public DistrictService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CrawlDistrict()
        {
            try
            {
                var provinceCode = "49";
                var urlGetDistrict = $"https://api.mysupership.vn/v1/partner/areas/district?province={provinceCode}";
                var urlGetCommuneBase = $"https://api.mysupership.vn/v1/partner/areas/commune?district=";
                var districts = new List<District>();

                using (var httpClient = new HttpClient())
                {
                    var districtResponse = await httpClient.GetAsync(urlGetDistrict);
                    var districtResponseContent = await districtResponse.Content.ReadAsStringAsync();
                    var districtResponseData = JsonConvert.DeserializeObject<BaseResponse<List<DistrictViewModel>>>(districtResponseContent);
                    if (districtResponseData.results != null && districtResponseData.results.Any())
                    {
                        foreach (var item in districtResponseData.results)
                        {
                            var urlGetCommune = urlGetCommuneBase + item.code;
                            var communeResponse = await httpClient.GetAsync(urlGetCommune);
                            var communeResponseContent = await communeResponse.Content.ReadAsStringAsync();
                            var communeResponseData = JsonConvert.DeserializeObject<BaseResponse<List<CommuneViewModel>>>(communeResponseContent);
                            if (communeResponseData.results != null && communeResponseData.results.Any())
                            {
                                foreach(var x in communeResponseData.results)
                                {
                                    var ward = await _repository.FindAsnyc<Ward>(s => s.ID_ward == x.code);
                                    if(ward != null)
                                    {
                                        ward.Name_ward = x.name;
                                        _repository.Update(ward);
                                    }
                                }
                            }
                        }
                    }
                    await _repository.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public async Task<List<District>> AllDistrict()
        {
            return await _repository.FindAllAsnyc<District>();
        }

        public async Task<List<Ward>> AllWard(string id)
        {
            return await _repository.FindAllAsnyc<Ward>(x => x.ID_district == id);
        }

        public async Task<List<Relief_classification>> AllRC()
        {
            return await _repository.FindAllAsnyc<Relief_classification>();
        }


        public async Task<Ward> GetWard(string id)
        {
            return await _repository.FindAsnyc<Ward>(x => x.ID_ward == id);
        }

        public async Task<District> GetDistrict(string id)
        {
            return await _repository.FindAsnyc<District>();
        }
    }
}
