
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblXuongChuyen")]
    [BasedOnRow(typeof(Entities.TblXuongChuyenRow), CheckNames = true)]
    public class TblXuongChuyenForm
    {
        [Tab("Xuong Chuyen")]
        [LookupEditor(typeof(Entities.TblNguoiDungRow))]
        public Int32 MaNvQuet { get; set; }
        public DateTime Ngay { get; set; }

        [Tab("Detail")]
        [TblXuongChuyenIn_ChiTietEditor]
        public List<Entities.TblXuongChuyenIn_ChiTietRow> DetailList { get; set; }
    }
}