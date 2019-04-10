
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblRefType")]
    [BasedOnRow(typeof(Entities.TblRefTypeRow), CheckNames = true)]
    public class TblRefTypeForm
    {
        public String TypeName { get; set; }
    }
}