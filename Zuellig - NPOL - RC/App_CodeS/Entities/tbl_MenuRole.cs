using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Entities
{
    public class tbl_MenuRole
    {
        private string rolecode;
        private bool news;
        private bool changePassword;

        private bool gAnnual;
        private bool registration;
        private bool approval;
        private bool leavereport;

        private bool gKPI;
        private bool kpi4Employee;
        private bool kpi4Manager;
        private bool kpiInfo;

        private bool gOther;
        private bool salary;
        private bool skill_will;

        private bool hrnew;
        private bool managerlevel;
        private bool adleavereport;
        private bool passmanagement;

        private bool otRegistration;
        private bool otRegisted;
        private bool otApproval;
        private bool otStatistic;

        private bool rcRegistration_TD;
        private bool rcRegistration_TT;
        private bool rcRegisted;
        private bool rcApproval;
        private bool rcStatistic;
        private bool viewRecruit;

        public tbl_MenuRole()
        {
            rolecode = "";
            news = false;
            changePassword = false;

            gAnnual = false;
            registration = false;
            approval = false;
            leavereport = false;

            gKPI = false;
            kpi4Employee = false;
            kpi4Manager = false;
            kpiInfo = false;

            gOther = false;
            salary = false;
            skill_will = false;

            hrnew = false;
            managerlevel = false;
            adleavereport = false;
            passmanagement = false;

            otRegistration = false;
            otStatistic = false;
            otRegisted = false;
            otApproval = false;

            rcRegistration_TD = false;
            rcRegistration_TT = false;
            rcStatistic = false;
            rcRegisted = false;
            rcApproval = false;
            viewRecruit = false;
        }

        #region properties
        public string RoleCode
        {
            get
            {
                return rolecode;
            }
            set
            {
                rolecode = value;
            }
        }
        public bool News
        {
            get
            {
                return news;
            }
            set
            {
                news = value;
            }
        }
        public bool ChangePassWord
        {
            get
            {
                return changePassword;
            }
            set
            {
                changePassword = value;
            }
        }

        public bool GAnnual
        {
            get
            {
                return gAnnual;
            }
            set
            {
                gAnnual = value;
            }
        }
        public bool Registration
        {
            get
            {
                return registration;
            }
            set
            {
                registration = value;
            }
        }

        public bool Approval
        {
            get
            {
                return approval;
            }
            set
            {
                approval = value;
            }
        }

        public bool LeaveReport
        {
            get
            {
                return leavereport;
            }
            set
            {
                leavereport = value;
            }
        }

        public bool GKPI
        {
            get
            {
                return gKPI;
            }
            set
            {
                gKPI = value;
            }
        }
        public bool KPI4Employee
        {
            get
            {
                return kpi4Employee;
            }
            set
            {
                kpi4Employee = value;
            }
        }
        public bool KPI4Manager
        {
            get
            {
                return kpi4Manager;
            }
            set
            {
                kpi4Manager = value;
            }
        }
        public bool KPIInfo
        {
            get
            {
                return kpiInfo;
            }
            set
            {
                kpiInfo = value;
            }
        }


        public bool GOther
        {
            get
            {
                return gOther;
            }
            set
            {
                gOther = value;
            }
        }
        public bool Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
            }
        }
        public bool Skill_Will
        {
            get
            {
                return skill_will;
            }
            set
            {
                skill_will = value;
            }
        }

        public bool HRNew
        {
            get
            {
                return hrnew;
            }
            set
            {
                hrnew = value;
            }
        }
        public bool ManagerLevel
        {
            get
            {
                return managerlevel;
            }
            set
            {
                managerlevel = value;
            }
        }

        public bool AdLeaveReport
        {
            get
            {
                return adleavereport;
            }
            set
            {
                adleavereport = value;
            }
        }

        public bool PassManagement
        {
            get
            {
                return passmanagement;
            }
            set
            {
                passmanagement = value;
            }
        }

        public bool OTStatistic
        {
            get { return otStatistic; }
            set { otStatistic = value; }
        }

        public bool OTApproval
        {
            get { return otApproval; }
            set { otApproval = value; }
        }

        public bool OTRegisted
        {
            get { return otRegisted; }
            set { otRegisted = value; }
        }

        public bool OTRegistration
        {
            get { return otRegistration; }
            set { otRegistration = value; }
        }

        public bool RCStatistic
        {
            get { return rcStatistic; }
            set { rcStatistic = value; }
        }

        public bool RCApproval
        {
            get { return rcApproval; }
            set { rcApproval = value; }
        }

        public bool RCRegisted
        {
            get { return rcRegisted; }
            set { rcRegisted = value; }
        }

        public bool RCRegistration_TD
        {
            get { return rcRegistration_TD; }
            set { rcRegistration_TD = value; }
        }
        public bool RCRegistration_TT
        {
            get { return rcRegistration_TT; }
            set { rcRegistration_TT = value; }
        }
        public bool ViewRecruit
        {
            get { return viewRecruit; }
            set { viewRecruit = value; }
        }
        #endregion
    }
}