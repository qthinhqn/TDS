
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.VNhapKhoSp")]
    [BasedOnRow(typeof(Entities.VNhapKhoSpRow), CheckNames = true)]
    public class VNhapKhoSpForm
    {
        public Int32 KeyId { get; set; }
        public Int32 MaKh { get; set; }
        public String TenKh { get; set; }
        public DateTime NgayNhap { get; set; }
        public Int32 NguoiNhap { get; set; }
        public String GhiChu { get; set; }
        public String MaBtp { get; set; }
        public Int32 SlThuc { get; set; }
        public Int32 SlLoiKh { get; set; }
        public Int32 SlLoiIn { get; set; }
        public String MaMau { get; set; }
        public String MaSize { get; set; }
        public String MaStyle { get; set; }
        public Boolean HangMau { get; set; }
        public Boolean HangBu { get; set; }
        public Int64 CardId { get; set; }
        public String Code { get; set; }
        public String Po { get; set; }
        public String Fepo { get; set; }
        public Int32 BulNo { get; set; }
        public String TableNum { get; set; }
        public String Buy { get; set; }
        public String Style04 { get; set; }
        public String Col { get; set; }
        public String Size { get; set; }
        public String Part { get; set; }
        public Int32 Quantity { get; set; }
    }
}