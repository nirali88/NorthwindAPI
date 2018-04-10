using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Model
{
    public class EmployeeDetail
    {
        public EmployeeDetail()
        {

        }

        public Employee objEmp { get; set; }
        public List<RepSales> lstSales { get; set; }
        public List<RepOrderSchedule> lstOrders { get; set; }

    }

    public class RepSales
    {
        public RepSales()
        {

        }

        public string Duration { get; set; }
        public decimal Rep_Sales { get; set; }
        public decimal Total_Sales { get; set; }
    }

    public class RepOrderSchedule
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipName { get; set; }
        public int EmployeeID { get; set; }
    }
}
