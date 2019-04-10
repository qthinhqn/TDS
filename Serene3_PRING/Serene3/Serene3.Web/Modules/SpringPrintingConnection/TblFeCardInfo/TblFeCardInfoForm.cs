
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblFeCardInfo")]
    [BasedOnRow(typeof(Entities.TblFeCardInfoRow), CheckNames = true)]
    public class TblFeCardInfoForm
    {
        public Int64 CardId { get; set; }
        public String RefBarCode { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ImportTime { get; set; }
    }
}