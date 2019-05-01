
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbRefReason4Adjust")]
    [BasedOnRow(typeof(Entities.TbRefReason4AdjustRow), CheckNames = true)]
    public class TbRefReason4AdjustColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId { get; set; }
        [EditLink]
        public String Reason { get; set; }
        public Boolean Active { get; set; }
    }
}