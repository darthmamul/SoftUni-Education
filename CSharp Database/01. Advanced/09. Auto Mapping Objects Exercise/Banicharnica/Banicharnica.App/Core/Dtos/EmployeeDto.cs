namespace Banicharnica.App.Core.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EmployeeDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public decimal Salary { get; set; }
    }
}
