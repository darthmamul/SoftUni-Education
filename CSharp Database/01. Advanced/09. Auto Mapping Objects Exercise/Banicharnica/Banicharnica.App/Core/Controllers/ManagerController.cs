namespace Banicharnica.App.Core.Controllers
{
    using System;
    using System.Linq;
    using App.Core.Contracts;
    using App.Core.Dtos;
    using AutoMapper.QueryableExtensions;
    using Banicharnica.Data;
    using Microsoft.EntityFrameworkCore;

    public class ManagerController : IManagerController
    {
        private readonly BanicharnicaContext context;

        public ManagerController(BanicharnicaContext context)
        {
            this.context = context;
        }

        public ManagerDto GetManagerInfo(int employeeId)
        {
            var employee = context.Employees
                .Where(x => x.Id == employeeId)
                .ProjectTo<ManagerDto>()
                .SingleOrDefault();

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id!");
            }

            return employee;
        }

        public void SetManager(int employeeId, int managerId)
        {
            var employee = this.context.Employees.Find(employeeId);

            var manager = this.context.Employees.Find(managerId);

            if (employee == null | manager == null)
            {
                throw new ArgumentException("Invalid Id!");
            }

            employee.Manager = manager;

            context.SaveChanges();
        }
    }
}
