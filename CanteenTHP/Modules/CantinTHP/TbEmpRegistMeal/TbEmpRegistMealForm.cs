
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

    [FormScript("CantinTHP.TbEmpRegistMeal")]
    [BasedOnRow(typeof(Entities.TbEmpRegistMealRow), CheckNames = true)]
    public class TbEmpRegistMealForm
    {
        [LookupEditor(typeof(TbEmployeeLookup))]
        public String EmpId { get; set; }
        public DateTime DDay { get; set; }
        public String ShiftId { get; set; }
        public String CanteenId { get; set; }
        public String MenuId { get; set; }
        public Int32 RegTypeId { get; set; }
        public Boolean IsPrinted { get; set; }
        public String Remarks { get; set; }
        public String CostCenter { get; set; }
        public DateTime CreatedDate { get; set; }
        public String UserCreate { get; set; }
        public Int32 ReasonId { get; set; }
        public String Notes { get; set; }
    }
}