
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.VChiTietBtp_Size")]
    [BasedOnRow(typeof(Entities.VChiTietBtp_SizeRow), CheckNames = true)]
    public class VChiTietBtp_SizeForm
    {
        public Int32 SlLoiKh { get; set; }
        public Int32 SlLoiIn { get; set; }
        public Int64 CardId { get; set; }
        public String Code { get; set; }
        public String MaBtp { get; set; }
        public Int32 SlThuc { get; set; }
        public String MaMau { get; set; }
        public String MaSize { get; set; }
        public String MaStyle { get; set; }
    }
}