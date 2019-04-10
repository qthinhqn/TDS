
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblHopDong_DieuChinh")]
    [BasedOnRow(typeof(Entities.TblHopDong_DieuChinhRow), CheckNames = true)]
    public class TblHopDong_DieuChinhForm
    {
        //public Int32 MaHd { get; set; }
        //public Int32 SlNhan { get; set; }
        //public Int32 SlNhanHu { get; set; }
        //public Int32 SlInHu { get; set; }
        //public Int32 SlXuat { get; set; }
        //public Int32 MaNv { get; set; }
        //public DateTime NgayDc { get; set; }
        //public Int32 MaChiTietHd { get; set; }
        //[LookupEditor(typeof(Entities.TblHopDongChiTietRow)), QuickFilter, ReadOnly(true)]
        //public Int32 MaChiTietHd { get; set; }
        [LookupEditor(typeof(Entities.TblNguoiDungRow))]
        public Int32 MaNv { get; set; }
        public Int32 SlNhan { get; set; }
        public Int32 SlNhanHu { get; set; }
        public Int32 SlInHu { get; set; }
        public Int32 SlXuat { get; set; }
            public DateTime NgayDc { get; set; }
    }
}