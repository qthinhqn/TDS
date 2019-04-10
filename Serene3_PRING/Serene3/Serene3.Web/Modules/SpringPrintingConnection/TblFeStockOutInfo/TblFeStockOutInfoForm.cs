
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblFeStockOutInfo")]
    [BasedOnRow(typeof(Entities.TblFeStockOutInfoRow), CheckNames = true)]
    public class TblFeStockOutInfoForm
    {
        public Int32 RfidOutputId { get; set; }
        public DateTime DDate { get; set; }
        public String Fty { get; set; }
        public String Po { get; set; }
        public String Fepo { get; set; }
        public Int64 CardId { get; set; }
        public String Code { get; set; }
        public Int32 BulNo { get; set; }
        public String TableNum { get; set; }
        public String Buy { get; set; }
        public String Style04 { get; set; }
        public String Col { get; set; }
        public String Size { get; set; }
        public String Part { get; set; }
        public String OpNo { get; set; }
        public String OpName { get; set; }
        public Int32 Quantity { get; set; }
        public DateTime ImportTime { get; set; }
    }
}