
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
        [FormCssClass("line-break-sm")]
        public String EmployeeId { get; set; }
        [HalfWidth(UntilNext = true)]
        public String LastName { get; set; }
        public String FirstName { get; set; }
        [Hidden]
        public String EmployeeName { get; set; }
        [GenderEditor]
        public String SexId { get; set; }
        public DateTime LeftDate { get; set; }
        public DateTime StartDate { get; set; }
        public Boolean Active { get; set; }
    }
}