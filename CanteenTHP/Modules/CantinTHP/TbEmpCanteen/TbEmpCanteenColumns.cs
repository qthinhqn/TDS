
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbEmpCanteen")]
    [BasedOnRow(typeof(Entities.TbEmpCanteenRow), CheckNames = true)]
    public class TbEmpCanteenColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        [Hidden]
        public Int32 KeyId { get; set; }
        [EditLink]
        public String StringName { get; set; }
        public String CanteenCanteenName { get; set; }
        public DateTime DateChange { get; set; }
        public Boolean Active { get; set; }
    }
}