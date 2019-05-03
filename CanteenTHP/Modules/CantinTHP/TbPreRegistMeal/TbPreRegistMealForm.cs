
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

    [FormScript("CantinTHP.TbPreRegistMeal")]
    [BasedOnRow(typeof(Entities.TbPreRegistMealRow), CheckNames = true)]
    public class TbPreRegistMealForm
    {
        //[LookupEditor(typeof(Entities.TbEmployeeRow))]
        [LookupEditor(typeof(TbEmployeeLookup))]
        public String EmpId { get; set; }
        [DefaultValue("now")]
        public DateTime DDay { get; set; }
        public String ShiftId { get; set; }
        [LookupEditor(typeof(TbRefCanteenLookup))]
        public String CanteenId { get; set; }
        public String MenuId { get; set; }
        public Int32 RegTypeId { get; set; }
        public Boolean IsPrinted { get; set; }
        public String Remarks { get; set; }
        public String CostCenter { get; set; }
        public DateTime CreatedDate { get; set; }
        public String UserCreate { get; set; }
    }
}