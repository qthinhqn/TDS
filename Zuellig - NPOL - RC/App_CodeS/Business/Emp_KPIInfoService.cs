using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOL.App_Code.Data;
using NPOL.App_Code.Entities;
using System.Data;

namespace NPOL.App_Code.Business
{
    public class Emp_KPIInfoService
    {
        public static DataTable GetDataTableById(int period_id)
        {
            Emp_KPIInfoDAO newsDAO = new Emp_KPIInfoDAO();
            return newsDAO.GetDataTableById("spGetDataTable_EmpKPIInfo", "tblEmpKPIInfo", period_id);
        }

        public static tblEmp_KPIInfo GetObjectById(string employeeid, int period_id)
        {
            Emp_KPIInfoDAO newsDAO = new Emp_KPIInfoDAO();
            return newsDAO.GetObjectById(employeeid, period_id);
        }

        public static int GetTypeById(int period_id)
        {
            Emp_KPIInfoDAO newsDAO = new Emp_KPIInfoDAO();
            return newsDAO.GetTypeById(period_id);
        }
        public static int GetYear(object EmployeeID)
        {
            Emp_KPIInfoDAO newsDAO = new Emp_KPIInfoDAO();
            return newsDAO.GetYear(EmployeeID);
        }
    }
}