
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblRefStyle")]
    [BasedOnRow(typeof(Entities.TblRefStyleRow), CheckNames = true)]
    public class TblRefStyleColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //public Int32 KeyId { get; set; }
        [EditLink]
        public String MaStyle { get; set; }
        public String TenStyle { get; set; }
    }
}