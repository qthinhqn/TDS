
namespace Canteen.CantinTHP.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;
    using Scripts;

    [FormScript("CantinTHP.TbEmpCompany")]
    [BasedOnRow(typeof(Entities.TbEmpCompanyRow), CheckNames = true)]
    public class TbEmpCompanyForm
    {
        //[LookupEditor(typeof(Entities.TbEmployeeRow))]
        [LookupEditor(typeof(TbEmployeeLookup))]
        public String EmpId { get; set; }
        [LookupEditor(typeof(Entities.TbRefCompanyRow))]
        public String CompanyKey { get; set; }
        public DateTime DateChange { get; set; }
        public String Remarks { get; set; }
    }
}