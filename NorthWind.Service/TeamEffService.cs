using NorthWind.DATA.Infrastructure;
using NorthWind.DATA.Repositories;
using NorthWind.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Service
{
    public interface ITeamEffService
    {
        IEnumerable<TeamMembers> GetEmployeeNames();
        EmployeeDetail GetEmployeeDetail(int employeeID, DateTime startDate, DateTime endDate);
    }

    public class TeamEffService : ITeamEffService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmployeeRepository employeeRepo;


        public TeamEffService(IUnitOfWork unitOfWork, IEmployeeRepository employeeRepo)
        {
            this.unitOfWork = unitOfWork;
            this.employeeRepo = employeeRepo;
        }

        public EmployeeDetail GetEmployeeDetail(int employeeID, DateTime startDate, DateTime endDate)
        {
            return employeeRepo.GetEmployeeDetail(employeeID, startDate, endDate);
        }

        public IEnumerable<TeamMembers> GetEmployeeNames()
        {
            return unitOfWork.SQLQuery<TeamMembers>("EXEC GetEmployeeNames", null);
        }
    }
}
