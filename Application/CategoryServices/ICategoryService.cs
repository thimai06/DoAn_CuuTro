using Models.EF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<categorize>> AllCategory();
    }
}
