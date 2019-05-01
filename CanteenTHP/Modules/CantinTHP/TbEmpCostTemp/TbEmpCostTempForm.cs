
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

    [FormScript("CantinTHP.TbEmpCostTemp")]
    [BasedOnRow(typeof(Entities.TbEmpCostTempRow), CheckNames = true)]
    public class TbEmpCostTempForm
    {
        //[LookupEditor(typeof(Entities.TbEmployeeRow))]
        [LookupEditor(typeof(TbEmployeeLookup))]
        public String EmpId { get; set; }
        public String CostId { get; set; }
        public DateTime DDay { get; set; }
        public String ShiftId { get; set; }
    }
}