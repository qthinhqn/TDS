
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblRefStyle")]
    [BasedOnRow(typeof(Entities.TblRefStyleRow), CheckNames = true)]
    public class TblRefStyleForm
    {
        public String MaStyle { get; set; }
        public String TenStyle { get; set; }
    }
}