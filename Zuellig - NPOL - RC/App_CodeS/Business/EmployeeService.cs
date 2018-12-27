using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOL.App_Code.Data;
using NPOL.App_Code.Entities;
using System.Data;

namespace NPOL.App_Code.Business
{
    public class EmployeeService
    {

        public static Employee_Info GetAttachmentById(string empID)
        {
            Employee_InfoDAO newsDAO = new Employee_InfoDAO();
            return newsDAO.GetAttachmentById( empID);
        }

        public static bool CheckViewSalary_EmpReplace(string empID, string managerID)
        {
            Employee_InfoDAO newsDAO = new Employee_InfoDAO();
            return newsDAO.CheckViewSalary_EmpReplace(empID, managerID);
        }
    }
}