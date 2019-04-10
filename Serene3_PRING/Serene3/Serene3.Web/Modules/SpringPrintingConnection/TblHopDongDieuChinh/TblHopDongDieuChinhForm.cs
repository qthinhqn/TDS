
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblHopDongDieuChinh")]
    [BasedOnRow(typeof(Entities.TblHopDongDieuChinhRow), CheckNames = true)]
    public class TblHopDongDieuChinhForm
    {
        [LookupEditor(typeof(Entities.TblHopDongChiTietRow)), QuickFilter, ReadOnly(true)]
        public Int32 MaChiTietHd { get; set; }
        public Int32 SlNhan { get; set; }
        public Int32 SlNhanHu { get; set; }
        public Int32 SlInHu { get; set; }
        public Int32 SlXuat { get; set; }
        [LookupEditor(typeof(Entities.TblNguoiDungRow)), QuickFilter]
        public Int32 MaNv { get; set; }
        public DateTime NgayDc { get; set; }
    }
}