
namespace Canteen.CantinTHP.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("CantinTHP.TbEmployee")]
    [BasedOnRow(typeof(Entities.TbEmployeeRow), CheckNames = true)]
    public class TbEmployeeForm
    {
        //[Category("Employee info")]
        [FormCssClass("line-break-sm"), HalfWidth]
        public String EmployeeId { get; set; }
        public String EmployeeName { get; set; }
        [HalfWidth(UntilNext = true)]
        public Boolean Active { get; set; }
        [ReadOnly(true)]
        public DateTime LeftDate { get; set; }

        [Category("Cantin Details")]
        [TbEmpCanteenEditor]
        public List<Entities.TbEmpCanteenRow> DetailList { get; set; }
    }
}