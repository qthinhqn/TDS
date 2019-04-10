
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.VLoSpKh")]
    [BasedOnRow(typeof(Entities.VLoSpKhRow), CheckNames = true)]
    public class VLoSpKhForm
    {
        public Int32 MaKh { get; set; }
        public String TenKh { get; set; }
    }
}