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
    [RoutePrefix("api")]
    public class TeamEffController : ApiController
    {
        private readonly ITeamEffService teamEffService;

        public TeamEffController(ITeamEffService _teamEffService)
        {
            teamEffService = _teamEffService;
        }

        [Route("GetEmployeeNames")]
        public HttpResponseMessage GetEmployeeNames()
        {
            try
            {
                var lst = teamEffService.GetEmployeeNames();

                if (lst != null)
                {
                    return Request.CreateResponse<IEnumerable<TeamMembers>>(HttpStatusCode.OK, lst);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Employees found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured during processing GetEmployeeNames ");
            }
        }

        [Route("GetEmployeeDetail/{employeeID}/{startDate}/{endDate}")]
        public HttpResponseMessage GetEmployeeDetail(int employeeID, DateTime startDate, DateTime endDate)
        {
            try
            {
                var obj = teamEffService.GetEmployeeDetail(employeeID, startDate, endDate);

                if (obj != null)
                {
                    return Request.CreateResponse<EmployeeDetail>(HttpStatusCode.OK, obj);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Employee found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured during processing GetCustomersByCountry ");
            }
        }

    }
}
