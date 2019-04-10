
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblXuongChuyenInChiTiet")]
    [BasedOnRow(typeof(Entities.TblXuongChuyenInChiTietRow), CheckNames = true)]
    public class TblXuongChuyenInChiTietForm
    {
        public Int32 MaBo { get; set; }
        public DateTime Ngay { get; set; }
        public Int32 MaXuongChuyen { get; set; }
        public Boolean Status { get; set; }
        [ReadOnly(true)]
        public Int32 CT_SL_Thuc { get; set; }
        [ReadOnly(true)]
        public Int32 CT_SL_Loi_KH { get; set; }
        public Int32 LoiIn { get; set; }
    }
}