
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbEmpCard")]
    [BasedOnRow(typeof(Entities.TbEmpCardRow), CheckNames = true)]
    public class TbEmpCardColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId { get; set; }
        [EditLink]
        public String StringName { get; set; }
        public String CardId { get; set; }
        public DateTime DateChange { get; set; }
        public String Remarks { get; set; }
        public Boolean Active { get; set; }
    }
}