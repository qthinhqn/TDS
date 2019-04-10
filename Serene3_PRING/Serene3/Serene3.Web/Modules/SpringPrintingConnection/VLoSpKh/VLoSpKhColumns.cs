
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.VLoSpKh")]
    [BasedOnRow(typeof(Entities.VLoSpKhRow), CheckNames = true)]
    public class VLoSpKhColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId1 { get; set; }
        public Int32 MaKh { get; set; }
        [EditLink]
        public String TenKh { get; set; }
    }
}