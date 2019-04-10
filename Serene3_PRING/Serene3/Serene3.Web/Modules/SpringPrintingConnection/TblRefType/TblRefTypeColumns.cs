
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblRefType")]
    [BasedOnRow(typeof(Entities.TblRefTypeRow), CheckNames = true)]
    public class TblRefTypeColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public String TypeId { get; set; }
        public String TypeName { get; set; }
    }
}