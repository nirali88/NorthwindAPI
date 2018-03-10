using Newtonsoft.Json;
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
    [RoutePrefix("api")]
    public class DashboardController : ApiController
    {
        private readonly IDashboardService dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }

        [Route("GetCustomerNamesByCountry/{country}")]
        public HttpResponseMessage GetCustomerNamesByCountry(string country)
        {
            try
            {
                var lst = dashboardService.GetCustomerNamesByCountry(country);

                if (lst != null)
                {
                    return Request.CreateResponse<IEnumerable<string>>(HttpStatusCode.OK, lst);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Customers found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured during processing GetCustomerNamesByCountry ");
            }
        }

        [Route("GetCustomersByCountry/{country}/{startDate}/{endDate}")]
        public HttpResponseMessage GetCustomersByCountry(string country, DateTime startDate, DateTime endDate)
        {
            try
            {
                var lst = dashboardService.GetCustomersByCountry(country, startDate, endDate);

                if (lst != null)
                {
                    return Request.CreateResponse<IEnumerable<string>>(HttpStatusCode.OK, lst);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Customers found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured during processing GetCustomersByCountry ");
            }
        }

        [Route("GetOrdersByCountry/{country}/{startDate}/{endDate}")]
        public HttpResponseMessage GetOrdersByCountry(string country, DateTime startDate, DateTime endDate)
        {
            try
            {
                var lst = dashboardService.GetOrdersByCountry(country, startDate, endDate);

                if (lst != null)
                {
                    return Request.CreateResponse<IEnumerable<string>>(HttpStatusCode.OK, lst);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No orders found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured during processing GetOrdersByCountry ");
            }
        }

        [Route("GetRevenuesByCountry/{country}/{startDate}/{endDate}")]
        public HttpResponseMessage GetRevenuesByCountry(string country, DateTime startDate, DateTime endDate)
        {
            try
            {
                var lst = dashboardService.GetRevenuesByCountry(country, startDate, endDate);

                if (lst != null)
                {
                    return Request.CreateResponse<IEnumerable<string>>(HttpStatusCode.OK, lst);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No records found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured during processing GetRevenuesByCountry ");
            }
        }

        [Route("GetSalesByCountry/{country}/{startDate}/{endDate}")]
        public HttpResponseMessage GetSalesByCountry(string country, DateTime startDate, DateTime endDate)
        {
            try
            {
                var lst = dashboardService.GetSalesByCountry(country, startDate, endDate);

                if (lst != null)
                {
                    return Request.CreateResponse<IEnumerable<string>>(HttpStatusCode.OK, lst);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No sales found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured during processing GetSalesByCountry ");
            }
        }
    }
}
