
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

    [FormScript("CantinTHP.TbEmpManager")]
    [BasedOnRow(typeof(Entities.TbEmpManagerRow), CheckNames = true)]
    public class TbEmpManagerForm
    {
        //[LookupEditor(typeof(Entities.TbEmployeeRow))]
        [LookupEditor(typeof(TbEmployeeLookup))]
        public String EmpId { get; set; }
        public Boolean IsManager { get; set; }
        [DefaultValue("now")]
        public DateTime DateChange { get; set; }
        public String Remarks { get; set; }
    }
}