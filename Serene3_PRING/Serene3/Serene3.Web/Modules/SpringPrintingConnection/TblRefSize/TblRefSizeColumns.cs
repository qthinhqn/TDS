
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblRefSize")]
    [BasedOnRow(typeof(Entities.TblRefSizeRow), CheckNames = true)]
    public class TblRefSizeColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //public Int32 KeyId { get; set; }
        [EditLink, Width(150)]
        public String MaSize { get; set; }
        [Width(250)]
        public String TenSize { get; set; }
    }
}