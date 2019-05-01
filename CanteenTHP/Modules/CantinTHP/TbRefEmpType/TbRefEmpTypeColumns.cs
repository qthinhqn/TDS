
namespace Canteen.CantinTHP.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("CantinTHP.TbRefEmpType")]
    [BasedOnRow(typeof(Entities.TbRefEmpTypeRow), CheckNames = true)]
    public class TbRefEmpTypeColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId { get; set; }
        [EditLink]
        public String TypeId { get; set; }
        public String TypeName { get; set; }
    }
}