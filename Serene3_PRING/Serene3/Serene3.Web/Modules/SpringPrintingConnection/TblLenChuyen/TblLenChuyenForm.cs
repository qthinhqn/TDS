
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblLenChuyen")]
    [BasedOnRow(typeof(Entities.TblLenChuyenRow), CheckNames = true)]
    public class TblLenChuyenForm
    {
        [Tab("Len chuyen")]
        [LookupEditor(typeof(Entities.TblNguoiDungRow))]
        public Int32 MaNvQuet { get; set; }
        public DateTime Ngay { get; set; }

        [Tab("Detail")]
        [TblLenChuyenIn_ChiTietEditor]
        public List<Entities.TblLenChuyenInChiTietRow> DetailList { get; set; }
    }
}