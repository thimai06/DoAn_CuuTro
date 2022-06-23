using Models.BaseRepository;
using Models.EF;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository _repository;

        public CategoryService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<categorize>> AllCategory()
        {
            return await _repository.FindAllAsnyc<categorize>();
        }
    }
}
