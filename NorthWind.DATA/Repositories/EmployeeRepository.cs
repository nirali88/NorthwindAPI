using NorthWind.DATA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind.Model;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Data;

namespace NorthWind.DATA.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public EmployeeDetail GetEmployeeDetail(int employeeID, DateTime startDate, DateTime endDate)
        {

            EmployeeDetail objEmployeeDetail = new EmployeeDetail()
            {
                lstOrders = new List<RepOrderSchedule>(),
                lstSales = new List<RepSales>(),
                objEmp = new Employee()
            };

            // Create a SQL command to execute the sproc
            var cmd = DbContext.Database.Connection.CreateCommand();
            cmd.CommandText = "[dbo].[GetEmployeeDetails]";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.DateTime));
            cmd.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.DateTime));

            cmd.Parameters[0].Value = employeeID;
            cmd.Parameters[1].Value = startDate;
            cmd.Parameters[2].Value = endDate;

            try
            {
                DbContext.Database.Connection.Open();

                //run the sp
                var reader = cmd.ExecuteReader();

                //Read employee from the first result set

                var employeeLst = ((IObjectContextAdapter)DbContext)
                .ObjectContext
                .Translate<Employee>(reader, "Employees", MergeOption.AppendOnly);

                foreach (var item in employeeLst)
                {
                    objEmployeeDetail.objEmp.EmployeeID = item.EmployeeID;
                    objEmployeeDetail.objEmp.Address = item.Address;
                    objEmployeeDetail.objEmp.BirthDate = item.BirthDate;
                    objEmployeeDetail.objEmp.City = item.City;
                    objEmployeeDetail.objEmp.Country = item.Country;
                    objEmployeeDetail.objEmp.Extension = item.Extension;
                    objEmployeeDetail.objEmp.FirstName = item.FirstName;
                    objEmployeeDetail.objEmp.HireDate = item.HireDate;
                    objEmployeeDetail.objEmp.HomePhone = item.HomePhone;
                    objEmployeeDetail.objEmp.LastName = item.LastName;
                    objEmployeeDetail.objEmp.Notes= item.Notes;
                    //objEmployeeDetail.objEmp.Orders = item.EmployeeID;
                    //objEmployeeDetail.objEmp.Photo = item.Photo;
                    objEmployeeDetail.objEmp.PhotoPath = item.PhotoPath;
                    objEmployeeDetail.objEmp.PostalCode = item.PostalCode;
                    objEmployeeDetail.objEmp.Region = item.Region;
                    objEmployeeDetail.objEmp.ReportsTo = item.ReportsTo;
                    objEmployeeDetail.objEmp.Title = item.Title;
                    objEmployeeDetail.objEmp.TitleOfCourtesy = item.TitleOfCourtesy;
                }

                // Move to second result set and read Rep Sales
                reader.NextResult();
                while (reader.Read())
                {
                    objEmployeeDetail.lstSales.Add(
                        new RepSales
                        {
                            Duration = reader.GetString(0),
                            Rep_Sales = reader.GetDecimal(1),
                            Total_Sales = reader.GetDecimal(2)
                        });
                }

                // Move to second result set and read Rep Ordes
                reader.NextResult();
                while (reader.Read())
                {
                    objEmployeeDetail.lstOrders.Add(
                        new RepOrderSchedule
                        {
                            OrderID = reader.GetInt32(0),
                            OrderDate = reader.GetDateTime(1),
                            ShipName = reader.GetString(2),
                            EmployeeID = employeeID
                        });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DbContext.Database.Connection.Close();
            }

            return objEmployeeDetail;

        }
    }

    public interface IEmployeeRepository : IRepository<Employee>
    {
        EmployeeDetail GetEmployeeDetail(int employeeID, DateTime startDate, DateTime endDate);
    }
}
