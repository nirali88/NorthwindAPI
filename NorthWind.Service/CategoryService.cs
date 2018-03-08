using NorthWind.DATA;
using NorthWind.DATA.Infrastructure;
using NorthWind.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind.Model;

namespace NorthWind.Service
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        //IEnumerable<Product> GetCategoryGadgets(string categoryName, string gadgetName = null);
        Category GetCategory(int id);
        void CreateCategory(Category category);
        void SaveCategory();
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitofWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitofWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitofWork = unitofWork;
        }
        
        public IEnumerable<Category> GetCategories()
        {
            return categoryRepository.GetAll();
        }

        public Category GetCategory(int id)
        {
            return categoryRepository.GetById(id);
        }

        public void CreateCategory(Category category)
        {
            categoryRepository.Add(category);
        }

        public void SaveCategory()
        {
            unitofWork.Commit();
        }
    }
}
