
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

    [FormScript("CantinTHP.TbEmpDepartment")]
    [BasedOnRow(typeof(Entities.TbEmpDepartmentRow), CheckNames = true)]
    public class TbEmpDepartmentForm
    {
        //[LookupEditor(typeof(Entities.TbEmployeeRow))]
        [LookupEditor(typeof(TbEmployeeLookup))]
        public String EmpId { get; set; }
        [LookupEditor(typeof(Entities.TbRefDepartmentRow))]
        public String DepKey { get; set; }
        [DefaultValue("now")]
        public DateTime DateChange { get; set; }
        public String Remarks { get; set; }
    }
}