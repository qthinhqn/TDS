
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblRefMau")]
    [BasedOnRow(typeof(Entities.TblRefMauRow), CheckNames = true)]
    public class TblRefMauColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //public Int32 KeyId { get; set; }
        [EditLink, Width(150)]
        public String MaMau { get; set; }
        [Width(250)]
        public String TenMau { get; set; }
    }
}