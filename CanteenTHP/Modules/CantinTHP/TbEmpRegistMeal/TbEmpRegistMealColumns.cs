
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbEmpRegistMeal")]
    [BasedOnRow(typeof(Entities.TbEmpRegistMealRow), CheckNames = true)]
    public class TbEmpRegistMealColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId { get; set; }
        [EditLink]
        public String EmpId { get; set; }
        public DateTime DDay { get; set; }
        public String ShiftShiftName { get; set; }
        public String CanteenCanteenName { get; set; }
        public String MenuMenuName { get; set; }
        public String RegTypeRegId { get; set; }
        public Boolean IsPrinted { get; set; }
        public String Remarks { get; set; }
        public String CostCenter { get; set; }
        public DateTime CreatedDate { get; set; }
        public String UserCreate { get; set; }
        public Int32 ReasonId { get; set; }
        public String Notes { get; set; }
    }
}