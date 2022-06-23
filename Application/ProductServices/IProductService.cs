using Models.EF;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductServices
{
    public interface IProductService
    {
        Task<List<Product>> AllProduct(string categoryId);
    }
}
