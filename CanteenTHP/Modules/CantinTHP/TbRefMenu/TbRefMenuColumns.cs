
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbRefMenu")]
    [BasedOnRow(typeof(Entities.TbRefMenuRow), CheckNames = true)]
    public class TbRefMenuColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId { get; set; }
        [EditLink]
        public String MenuId { get; set; }
        public String MenuName { get; set; }
        public String MImage { get; set; }
        public String Remarks { get; set; }
        public Boolean Active { get; set; }
    }
}