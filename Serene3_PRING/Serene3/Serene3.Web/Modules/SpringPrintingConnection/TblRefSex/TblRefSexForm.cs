
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblRefSex")]
    [BasedOnRow(typeof(Entities.TblRefSexRow), CheckNames = true)]
    public class TblRefSexForm
    {
        public String SexName { get; set; }
    }
}