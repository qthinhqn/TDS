
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

    [FormScript("CantinTHP.TbEmpCanteen")]
    [BasedOnRow(typeof(Entities.TbEmpCanteenRow), CheckNames = true)]
    public class TbEmpCanteenForm
    {
        //[LookupEditor(typeof(Entities.TbEmployeeRow))]
        [LookupEditor(typeof(TbEmployeeLookup))]
        public String EmpId { get; set; }
        [LookupEditor(typeof(TbRefCanteenLookup))]
        public String CanteenId { get; set; }
        [DefaultValue("now")]
        public DateTime DateChange { get; set; }
        public Boolean Active { get; set; }
    }
}