
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.VHopDongTrangThai")]
    [BasedOnRow(typeof(Entities.VHopDongTrangThaiRow), CheckNames = true)]
    public class VHopDongTrangThaiForm
    {
        public DateTime NgayHd { get; set; }
        public String NoiDung { get; set; }
        public Double GiaTri { get; set; }
        public String SoHd { get; set; }
        public String TenKh { get; set; }
        public String MaKh { get; set; }
        public String MotaBtp { get; set; }
        public String DonViTinh { get; set; }
        public Int32 MaMau { get; set; }
        public String TenMau { get; set; }
        public Int32 MaSize { get; set; }
        public String TenSize { get; set; }
        public Int32 MaStyle { get; set; }
        public String TenStyle { get; set; }
        public Int32 SoLuong { get; set; }
        public Double DonGia { get; set; }
        public Double ThanhTien { get; set; }
        public Int32 SlNhap { get; set; }
        public Int32 SlLoiKh { get; set; }
        public Int32 SlLoiIn { get; set; }
        public Int32 SlThucXuat { get; set; }
        public Int32 SlThieu { get; set; }
    }
}