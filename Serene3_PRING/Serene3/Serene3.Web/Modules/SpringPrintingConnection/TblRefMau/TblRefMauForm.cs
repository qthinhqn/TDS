
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblRefMau")]
    [BasedOnRow(typeof(Entities.TblRefMauRow), CheckNames = true)]
    public class TblRefMauForm
    {
        public String MaMau { get; set; }
        public String TenMau { get; set; }
    }
}