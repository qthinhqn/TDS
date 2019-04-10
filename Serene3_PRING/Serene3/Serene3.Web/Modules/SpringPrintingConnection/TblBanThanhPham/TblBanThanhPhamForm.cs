
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblBanThanhPham")]
    [BasedOnRow(typeof(Entities.TblBanThanhPhamRow), CheckNames = true)]
    public class TblBanThanhPhamForm
    {
        public String MotaBtp { get; set; }
        public String DonViTinh { get; set; }
        [DefaultValue("now")]
        public DateTime NgayTao { get; set; }
        public Boolean Status { get; set; }
    }
}