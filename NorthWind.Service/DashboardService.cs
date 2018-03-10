using NorthWind.DATA.Infrastructure;
using NorthWind.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NorthWind.Service
{
    public interface IDashboardService
    {
        IEnumerable<String> GetCustomerNamesByCountry(string country);
        IEnumerable<string> GetCustomersByCountry(string country, DateTime startDate, DateTime endDate);
        IEnumerable<string> GetOrdersByCountry(string country, DateTime startDate, DateTime endDate);
        IEnumerable<string> GetRevenuesByCountry(string country, DateTime startDate, DateTime endDate);
        IEnumerable<string> GetSalesByCountry(string country, DateTime startDate, DateTime endDate);
    }

    public class DashboardService : IDashboardService
    {
        private readonly IUnitOfWork unitOfWork;

        public DashboardService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<string> GetCustomerNamesByCountry(string country)
        {
            return unitOfWork.SQLQuery<string>("EXEC GetCustomerNamesByCountry @Country", new SqlParameter("Country", SqlDbType.VarChar) { Value = country });
        }

        public IEnumerable<string> GetCustomersByCountry(string country, DateTime startDate, DateTime endDate)
        {
            return unitOfWork.SQLQuery<string>("EXEC GetCustomersByCountry @Country,@StartDate,@EndDate",
                new SqlParameter("Country", SqlDbType.VarChar) { Value = country },
                new SqlParameter("StartDate", SqlDbType.DateTime) { Value = startDate },
                new SqlParameter("EndDate", SqlDbType.DateTime) { Value = endDate });
        }

        public IEnumerable<string> GetOrdersByCountry(string country, DateTime startDate, DateTime endDate)
        {
            return unitOfWork.SQLQuery<string>("EXEC GetOrdersByCountry @Country,@StartDate,@EndDate",
                new SqlParameter("Country", SqlDbType.VarChar) { Value = country },
                new SqlParameter("StartDate", SqlDbType.DateTime) { Value = startDate },
                new SqlParameter("EndDate", SqlDbType.DateTime) { Value = endDate });
        }

        public IEnumerable<string> GetRevenuesByCountry(string country, DateTime startDate, DateTime endDate)
        {
            return unitOfWork.SQLQuery<string>("EXEC GetOrdersByCountry @Country,@StartDate,@EndDate",
               new SqlParameter("Country", SqlDbType.VarChar) { Value = country },
               new SqlParameter("StartDate", SqlDbType.DateTime) { Value = startDate },
               new SqlParameter("EndDate", SqlDbType.DateTime) { Value = endDate });
        }

        public IEnumerable<string> GetSalesByCountry(string country, DateTime startDate, DateTime endDate)
        {
            return unitOfWork.SQLQuery<string>("EXEC GetSalesByCountry @Country,@StartDate,@EndDate",
               new SqlParameter("Country", SqlDbType.VarChar) { Value = country },
               new SqlParameter("StartDate", SqlDbType.DateTime) { Value = startDate },
               new SqlParameter("EndDate", SqlDbType.DateTime) { Value = endDate });
        }
    }
}
