using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPOL
{

    public class Employee
    {
        public List<Employee> EmployeeList = new List<Employee>();

        private string employeeId, employeeName;
        public Employee(string EmployeeId, string EmployeeName)
        {
            employeeId = EmployeeId;
            employeeName = EmployeeName;

        }
        public String EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }
        public String EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }

        }
    }
     
}