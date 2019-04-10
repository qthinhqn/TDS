
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblLoSp")]
    [BasedOnRow(typeof(Entities.TblLoSpRow), CheckNames = true)]
    public class TblLoSpForm
    {
        [Tab("Lo nhap")]
        [ReadOnly(true)]
        public Int32 KeyId { get; set; }

        [LookupEditor(typeof(Entities.TblKhachHangRow))]
        public Int32 MaKh { get; set; }
        public DateTime NgayNhap { get; set; }
        [LookupEditor(typeof(Entities.TblNguoiDungRow))]
        public Int32 NguoiNhap { get; set; }
        public Int32 SoLuong { get; set; }
        public String GhiChu { get; set; }

        [Tab("Details")]
        [TblBo_BTPEditor]
        public List<Entities.TblBo_BTPRow> DetailList { get; set; }
    }
}