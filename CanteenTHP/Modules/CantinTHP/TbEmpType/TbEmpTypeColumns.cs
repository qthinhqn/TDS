
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbEmpType")]
    [BasedOnRow(typeof(Entities.TbEmpTypeRow), CheckNames = true)]
    public class TbEmpTypeColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId { get; set; }
        [EditLink]
        public String StringName { get; set; }
        public String TypeTypeId { get; set; }
        public DateTime DateChange { get; set; }
        public String Remarks { get; set; }
    }
}