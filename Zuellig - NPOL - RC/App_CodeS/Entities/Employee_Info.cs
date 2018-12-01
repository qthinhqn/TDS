using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Entities
{
    public class Employee_Info
    {
        private string employeeId, employeeName;
        private DateTime? leftDate;
        private DateTime? maternityDate;
        private double salary;
        public Employee_Info()
        {
            employeeId = "";
            employeeName = "";

        }
        public Employee_Info(string EmployeeId, string EmployeeName)
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
        public DateTime? LeftDate
        {
            get { return leftDate; }
            set { leftDate = value; }
        }
        public double Salary
        {
            get { return salary; }
            set { salary = value; }

        }
        public DateTime? MaternityDate
        {
            get { return maternityDate; }
            set { maternityDate = value; }
        }
    }
     
}