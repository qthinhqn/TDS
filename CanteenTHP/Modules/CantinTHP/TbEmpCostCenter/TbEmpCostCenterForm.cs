
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

    [FormScript("CantinTHP.TbEmpCostCenter")]
    [BasedOnRow(typeof(Entities.TbEmpCostCenterRow), CheckNames = true)]
    public class TbEmpCostCenterForm
    {
        //[LookupEditor(typeof(Entities.TbEmployeeRow))]
        [LookupEditor(typeof(TbEmployeeLookup))]
        public String EmpId { get; set; }
        [LookupEditor(typeof(Entities.TbRefCostCenterRow))]
        public String CostCenter { get; set; }
        public DateTime DateChange { get; set; }
        public String Remarks { get; set; }
    }
}