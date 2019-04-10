
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblRefSize")]
    [BasedOnRow(typeof(Entities.TblRefSizeRow), CheckNames = true)]
    public class TblRefSizeForm
    {
        public String MaSize { get; set; }
        public String TenSize { get; set; }
    }
}