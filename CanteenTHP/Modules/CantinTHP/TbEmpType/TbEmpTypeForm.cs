
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

    [FormScript("CantinTHP.TbEmpType")]
    [BasedOnRow(typeof(Entities.TbEmpTypeRow), CheckNames = true)]
    public class TbEmpTypeForm
    {
        //[LookupEditor(typeof(Entities.TbEmployeeRow))]
        [LookupEditor(typeof(TbEmployeeLookup))]
        public String EmpId { get; set; }
        public Int32 TypeId { get; set; }
        public DateTime DateChange { get; set; }
        public String Remarks { get; set; }
    }
}