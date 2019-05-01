
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

    [FormScript("CantinTHP.TbEmpCard")]
    [BasedOnRow(typeof(Entities.TbEmpCardRow), CheckNames = true)]
    public class TbEmpCardForm
    {
        //[LookupEditor(typeof(Entities.TbEmployeeRow))]
        [LookupEditor(typeof(TbEmployeeLookup))]
        public String EmpId { get; set; }
        public String CardId { get; set; }
        public DateTime DateChange { get; set; }
        public String Remarks { get; set; }
        public Boolean Active { get; set; }
    }
}