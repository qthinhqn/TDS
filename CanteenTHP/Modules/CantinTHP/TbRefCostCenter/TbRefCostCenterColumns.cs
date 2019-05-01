
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbRefCostCenter")]
    [BasedOnRow(typeof(Entities.TbRefCostCenterRow), CheckNames = true)]
    public class TbRefCostCenterColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId { get; set; }
        [EditLink]
        public String CostCenter { get; set; }
        public String Remarks { get; set; }
        public Boolean IsTemp { get; set; }
        public DateTime CreatedDate { get; set; }
        public String UserCreate { get; set; }
        public Boolean Active { get; set; }
    }
}