
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblHopDong")]
    [BasedOnRow(typeof(Entities.TblHopDongRow), CheckNames = true)]
    public class TblHopDongForm
    {
        [Tab("PO")]
        [LookupEditor(typeof(Entities.TblKhachHangRow)), QuickFilter]
        public Int32 MaKh { get; set; }
        public DateTime NgayHd { get; set; }
        public String NoiDung { get; set; }
        public Double GiaTri { get; set; }
        public String SoHd { get; set; }
        [LookupEditor(typeof(Entities.TblNguoiDungRow)), QuickFilter, ]
        public Int32 NvTao { get; set; }
        //public DateTime Ngay { get; set; }

        [Tab("PO Detail")]
        [TblHopDongChiTiet_Editor]
        public List<Entities.TblHopDong_ChiTietRow> DetailList { get; set; }
    }
}