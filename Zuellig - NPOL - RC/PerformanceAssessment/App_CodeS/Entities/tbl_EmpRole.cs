using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Entities
{
    public class tbl_EmpRole
    {
        private string empid;
        private string leaveManager;
        private string leaveEmployee;
        private string managerKPI;
        private string employeeKPI;

        private string groupCode;

        public tbl_EmpRole()
        {
            empid = "";
            leaveManager = "";
            leaveEmployee = "";
            managerKPI = "";
            employeeKPI = "";
            groupCode = "";
        }

        #region properties
        public string EmpID
        {
            get
            {
                return empid;
            }
            set
            {
                empid = value;
            }
        }
        public string LeaveManager
        {
            get
            {
                return leaveManager;
            }
            set
            {
                leaveManager = value;
            }
        }
        public string LeaveEmployee
        {
            get
            {
                return leaveEmployee;
            }
            set
            {
                leaveEmployee = value;
            }
        }
        public string ManagerKPI
        {
            get
            {
                return managerKPI;
            }
            set
            {
                managerKPI = value;
            }
        }

        public string EmployeeKPI
        {
            get
            {
                return employeeKPI;
            }
            set
            {
                employeeKPI = value;
            }
        }

        public string GroupCode
        {
            get
            {
                return groupCode;
            }
            set
            {
                groupCode = value;
            }
        }
        #endregion
    }
}