using AutoMapper;
using NorthWind.Model;
using NorthWind.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace NorthWindWebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ProductController : ApiController
    {
        private readonly IProductService productService;
        private readonly ISupplierService supplierService;
        private readonly ICategoryService categoryService;

        public ProductController(IProductService productService, ISupplierService supplierService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.supplierService = supplierService;
            this.categoryService = categoryService;
        }

        public HttpResponseMessage GetAll()
        {
            try
            {
                var lstProduct = productService.GetProducts().ToList();

                IEnumerable<ProductsListVM> lst = new List<ProductsListVM>();

                lst = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductsListVM>>(lstProduct);

                if (lstProduct != null)
                {
                    return Request.CreateResponse<IEnumerable<ProductsListVM>>(HttpStatusCode.OK, lst);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Products found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured during processing GetAll ");
            }
        }

        public HttpResponseMessage GetByID(int id)
        {
            try
            {
                var product = productService.GetProduct(id);

                AddEditProductVM obj = new AddEditProductVM();

                obj = Mapper.Map<Product, AddEditProductVM>(product);

                if (obj != null)
                {
                    return Request.CreateResponse<AddEditProductVM>(HttpStatusCode.OK, obj);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Products found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured during processing GetAll ");
            }
        }

        public HttpResponseMessage Post([FromBody]AddEditProductVM objProduct)
        {
            try
            {
                var product = Mapper.Map<Product>(objProduct);
                productService.CreateProduct(product);
                productService.SaveProduct();

                var message= Request.CreateResponse<Product>(HttpStatusCode.Created,product);
                message.Headers.Location = new Uri(Request.RequestUri+product.ProductID.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured during creating product");
            }
        }

        public HttpResponseMessage Put(int id, [FromBody]AddEditProductVM objProduct)
        {
            try
            {
                var product = productService.GetProduct(id);

                if (product == null)
                {
                    return Request.CreateResponse<Product>(HttpStatusCode.NotFound, product);
                }
                Mapper.Map<AddEditProductVM,Product>(objProduct,product);
               productService.Update(product);
                productService.SaveProduct();

                return Request.CreateResponse<Product>(HttpStatusCode.OK,null);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured during updating product");
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var product = productService.GetProduct(id);

                if (product == null)
                {
                    return Request.CreateResponse<Product>(HttpStatusCode.NotFound, product);
                }
                productService.Delete(product);
                productService.SaveProduct();

                return Request.CreateResponse<Product>(HttpStatusCode.OK, product);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured during deleting product");
            }
        }

        [Route("api/category/select")]
        public HttpResponseMessage GetCategorySelect()
        {
            try
            {
                var lstCats = categoryService.GetCategories();

                IEnumerable<SelectListVM> lst = new List<SelectListVM>();

                lst = Mapper.Map<IEnumerable<Category>, IEnumerable<SelectListVM>>(lstCats);

                if (lstCats != null)
                {
                    return Request.CreateResponse<IEnumerable<SelectListVM>>(HttpStatusCode.OK, lst);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Categories found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured during processing GetAll ");
            }
        }

        [Route("api/supplier/select")]
        public HttpResponseMessage GetSupplierSelect()
        {
            try
            {
                var lstSuppliers = supplierService.GetSuppliers();

                IEnumerable<SelectListVM> lst = new List<SelectListVM>();

                lst = Mapper.Map<IEnumerable<Supplier>, IEnumerable<SelectListVM>>(lstSuppliers);

                if (lstSuppliers != null)
                {
                    return Request.CreateResponse<IEnumerable<SelectListVM>>(HttpStatusCode.OK, lst);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Suppliers found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured during processing GetAll ");
            }
        }
    }
}
