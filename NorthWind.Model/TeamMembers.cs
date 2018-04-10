using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthWind.Model
{
    public class TeamMembers
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
    }
}