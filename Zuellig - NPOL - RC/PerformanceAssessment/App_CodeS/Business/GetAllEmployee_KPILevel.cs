using PAOL.App_Code.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Business
{
    public class Employee_KPILevelService
    {
        public static DataTable GetAllEmployee_KPILevel()
        {
            Employee_KPILevelDAO newsDAO = new Employee_KPILevelDAO();
            return newsDAO.GetAllEmployee_KPILevel("spKPI_GetAllEmployee_KPILevel", "Employee_KPILevel");
        }
    }
}