
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.VTrangThaiBoBtp")]
    [BasedOnRow(typeof(Entities.VTrangThaiBoBtpRow), CheckNames = true)]
    public class VTrangThaiBoBtpForm
    {
        public Int64 CardId { get; set; }
        public String Code { get; set; }
        public Int32 MaBtp { get; set; }
        public String TenBtp { get; set; }
        public Int32 SlThuc { get; set; }
        public Int32 SlLoiKh { get; set; }
        public Int32 SlLoiIn { get; set; }
        public String MaMau { get; set; }
        public String MaSize { get; set; }
        public String MaStyle { get; set; }
        public DateTime Ngay1 { get; set; }
        public Int32 NhanVien1 { get; set; }
        public DateTime Ngay2 { get; set; }
        public Int32 NhanVien2 { get; set; }
        public DateTime Ngay3 { get; set; }
        public Int32 NhanVien3 { get; set; }
        public DateTime Ngay4 { get; set; }
        public Int32 NhanVien4 { get; set; }
        public Boolean HangMau { get; set; }
        public Boolean HangBu { get; set; }
        public Int32 MaHd { get; set; }
    }
}