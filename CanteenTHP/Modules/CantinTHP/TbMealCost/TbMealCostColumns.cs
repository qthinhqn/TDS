
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbMealCost")]
    [BasedOnRow(typeof(Entities.TbMealCostRow), CheckNames = true)]
    public class TbMealCostColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId { get; set; }
        public DateTime DateChange { get; set; }
        public Double EmployeeCost { get; set; }
        public Double ManagerCost { get; set; }
        [EditLink]
        public String Remarks { get; set; }
    }
}