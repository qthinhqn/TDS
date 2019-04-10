
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.VHopDongChiTiet")]
    [BasedOnRow(typeof(Entities.VHopDongChiTietRow), CheckNames = true)]
    public class VHopDongChiTietForm
    {
        public DateTime NgayHd { get; set; }
        public String NoiDung { get; set; }
        public Double GiaTri { get; set; }
        public String SoHd { get; set; }
        public String TenKh { get; set; }
        public String MaKh { get; set; }
        public Int32 MaBtp { get; set; }
        public String MotaBtp { get; set; }
        public String DonViTinh { get; set; }
        public String MaMau { get; set; }
        public String TenMau { get; set; }
        public String MaSize { get; set; }
        public String TenSize { get; set; }
        public String MaStyle { get; set; }
        public String TenStyle { get; set; }
        public Int32 SoLuong { get; set; }
        public Double DonGia { get; set; }
        public Double ThanhTien { get; set; }
    }
}