
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblHopDong_ChiTiet")]
    [BasedOnRow(typeof(Entities.TblHopDong_ChiTietRow), CheckNames = true)]
    public class TblHopDong_ChiTietColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //public Int32 KeyId { get; set; }
        [EditLink, Width(150)]
        public String MaBtpMotaBtp { get; set; }
        [Width(100)]
        public String MaMauTenMau { get; set; }
        [Width(100)]
        public String MaSizeTenSize { get; set; }
        [Width(100)]
        public String MaStyleTenStyle { get; set; }
        [Width(120), AlignRight]
        public Int32 SoLuong { get; set; }
        [Width(100), AlignRight]
        public Double DonGia { get; set; }
        [Width(100), AlignRight]
        public Double ThanhTien { get; set; }
        //public String MaHdNoiDung { get; set; }
        //public String MaBtpMotaBtp { get; set; }
        //public String MaMau1 { get; set; }
        //public String MaSize1 { get; set; }
        //public Int32 SoLuong { get; set; }
        //public Double DonGia { get; set; }
        //public Double ThanhTien { get; set; }
        //public Int32 MaStyle { get; set; }
    }
}