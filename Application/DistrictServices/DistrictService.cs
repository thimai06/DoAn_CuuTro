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
                            var district = new District()
                            {
                                ID_district = item.code,
                                Name_district = item.name,
                            };
                            var urlGetCommune = urlGetCommuneBase + item.code;
                            var communeResponse = await httpClient.GetAsync(urlGetCommune);
                            var communeResponseContent = await communeResponse.Content.ReadAsStringAsync();
                            var communeResponseData = JsonConvert.DeserializeObject<BaseResponse<List<CommuneViewModel>>>(communeResponseContent);
                            if (communeResponseData.results != null && communeResponseData.results.Any())
                            {
                                communeResponseData.results.ForEach(x =>
                                {
                                    district.Wards.Add(new Ward()
                                    {
                                        ID_ward = x.code,
                                        ID_district = district.ID_district,
                                        Name_ward = item.name,
                                    });
                                });
                            }
                            districts.Add(district);
                        }
                    }

                    _repository.AddRange(districts);
                    await _repository.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
