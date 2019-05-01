
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

    [FormScript("CantinTHP.TbEmpDayOff")]
    [BasedOnRow(typeof(Entities.TbEmpDayOffRow), CheckNames = true)]
    public class TbEmpDayOffForm
    {
        //[LookupEditor(typeof(Entities.TbEmployeeRow))]
        [LookupEditor(typeof(TbEmployeeLookup))]
        public String EmpId { get; set; }
        [LookupEditor(typeof(Entities.TbRefLeaveTypeRow))]
        public String LeaveId { get; set; }
        public String LeaveType { get; set; }
        public DateTime DateChange { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public String Remarks { get; set; }
    }
}