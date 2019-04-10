
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.VChiTietBtp")]
    [BasedOnRow(typeof(Entities.VChiTietBtpRow), CheckNames = true)]
    public class VChiTietBtpColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId1 { get; set; }
        public Int64 CardId { get; set; }
        [EditLink]
        public String Code { get; set; }
        public String MaBtp { get; set; }

        [Width(120), AlignRight]
        public Int32 SlThuc { get; set; }

        [Width(120), AlignRight]
        public Int32 SlLoiKh { get; set; }

        [Width(120), AlignRight]
        public Int32 SlLoiIn { get; set; }
        public String MaMau { get; set; }
        public String MaSize { get; set; }
        public String MaStyle { get; set; }
    }
}