using Models.BaseRepository;
using Models.EF;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IRepository _repository;

        public ProductService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> AllProduct(string categoryId)
        {
            return await _repository.FindAllAsnyc<Product>(x => x.ID_cate == categoryId);
        }
    }
}
