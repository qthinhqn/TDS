using NPOL.App_Code.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Business
{
    public class Employee_KPILevelService
    {
        public static DataTable GetAllEmployee_KPILevel()
        {
            Employee_KPILevelDAO newsDAO = new Employee_KPILevelDAO();
            return newsDAO.GetAllEmployee_KPILevel("spKPI_GetAllEmployee_KPILevel", "Employee_KPILevel");
        }
        public static ArrayList GetAllManager_KPILevel(string EmpID)
        {
            Employee_KPILevelDAO newsDAO = new Employee_KPILevelDAO();
            return newsDAO.GetAllManager_KPILevel(EmpID);
        }
    }
}