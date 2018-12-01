using PAOL.App_Code.Data;
using PAOL.App_Code.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Business
{
    public class Assessment_CompetencyService
    {
        public bool Update(string EmployeeID, int PeriodID)
        {
            Competency_KPIDAO newDAO = new Competency_KPIDAO();
            return newDAO.UpdateScore("spKPI_subrpt_CompetencyInfo", EmployeeID, PeriodID);
        }

    }
}