using AutoMapper;
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
    public class OrderController : ApiController
    {
        public IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public HttpResponseMessage GetAll()
        {
            try
            {
                IEnumerable<OrderListVM> lstOrders = Mapper.Map<IEnumerable<OrderListVM>>(orderService.GetOrders().ToList());

                if (lstOrders != null)
                {
                    return Request.CreateResponse<IEnumerable<OrderListVM>>(HttpStatusCode.OK, lstOrders);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Orders found");
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
                OrderListVM objOrder = Mapper.Map<OrderListVM>(orderService.GetOrder(id));

                if (objOrder != null)
                {
                    return Request.CreateResponse<OrderListVM>(HttpStatusCode.OK, objOrder);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Orders found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured during processing GetByID ");
            }
        }

        [Route("api/orderlines/{id}")]
        public HttpResponseMessage GetItemsByID(int id)
        {
            try
            {
                IEnumerable<OrderItems> orderLines = Mapper.Map<IEnumerable<OrderItems>>(orderService.GetOrderLines(id));

                if (orderLines != null)
                {
                    return Request.CreateResponse<IEnumerable<OrderItems>>(HttpStatusCode.OK, orderLines);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Orders Items found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured during processing GetByID ");
            }
        }
    }
}
