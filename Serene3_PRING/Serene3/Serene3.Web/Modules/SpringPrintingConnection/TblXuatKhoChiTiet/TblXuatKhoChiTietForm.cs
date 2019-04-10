
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblXuatKhoChiTiet")]
    [BasedOnRow(typeof(Entities.TblXuatKhoChiTietRow), CheckNames = true)]
    public class TblXuatKhoChiTietForm
    {
        public Int32 MaBo { get; set; }
        public DateTime Ngay { get; set; }
        public Boolean Status { get; set; }
        public Int32 MaPhieuXuat { get; set; }
    }
}