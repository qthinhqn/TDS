
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblLoSp")]
    [BasedOnRow(typeof(Entities.TblLoSpRow), CheckNames = true)]
    public class TblLoSpColumns
    {
        [EditLink,  AlignCenter]
        public Int32 KeyId { get; set; }
        //public Int32 MaKh { get; set; }
        [EditLink, Width(200)]
        public String TenKH { get; set; }
        public DateTime NgayNhap { get; set; }
        [AlignRight]
        public Int32 SoLuong { get; set; }
        [Width(300)]
        public String GhiChu { get; set; }
        public String NguoiNhapHoTen { get; set; }
        //[Width(120)]
        //public string Note { get; set; }
    }
}