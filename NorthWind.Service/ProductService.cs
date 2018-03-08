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
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        //IEnumerable<Product> GetCategoryGadgets(string categoryName, string gadgetName = null);
        Product GetProduct(int id);
        void Update(Product product);
        void Delete(Product product);
        void CreateProduct(Product product);
        void SaveProduct();
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository productsRepository;
        private readonly IUnitOfWork unitofWork;

        public ProductService(IProductRepository productsRepository, IUnitOfWork unitofWork)
        {
            this.productsRepository = productsRepository;
            this.unitofWork = unitofWork;
        }

        public void CreateProduct(Product product)
        {
            productsRepository.Add(product);
        }

        public Product GetProduct(int id)
        {
            return productsRepository.GetById(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return productsRepository.GetAll();
        }

        public void Update(Product product)
        {
            productsRepository.Update(product);
        }

        public void Delete(Product product)
        {
            productsRepository.Delete(product);
        }

        public void SaveProduct()
        {
            unitofWork.Commit();
        }
    }
}
