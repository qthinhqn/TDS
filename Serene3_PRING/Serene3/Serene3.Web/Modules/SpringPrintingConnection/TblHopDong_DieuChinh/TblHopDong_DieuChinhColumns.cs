
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblHopDong_DieuChinh")]
    [BasedOnRow(typeof(Entities.TblHopDong_DieuChinhRow), CheckNames = true)]
    public class TblHopDong_DieuChinhColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //public Int32 KeyId { get; set; }
        //public Int32 MaHd { get; set; }
        //public Int32 SlNhan { get; set; }
        //public Int32 SlNhanHu { get; set; }
        //public Int32 SlInHu { get; set; }
        //public Int32 SlXuat { get; set; }
        //public String MaNvHoTen { get; set; }
        //public DateTime NgayDc { get; set; }
        //public Int32 MaChiTietHd { get; set; }
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //public Int32 KeyId { get; set; }
        //[EditLink, Width(100)]
        //public Int32 MaChiTietHd { get; set; }
        [EditLink, Width(150)]
        [LookupEditor(typeof(Entities.TblNguoiDungRow))]
        public String MaNvHoTen { get; set; }
        [EditLink,Width(120), AlignRight]
        public Int32 SlNhan { get; set; }
        [Width(120), AlignRight]
        public Int32 SlNhanHu { get; set; }
        [Width(120), AlignRight]
        public Int32 SlInHu { get; set; }
        [Width(120), AlignRight]
        public Int32 SlXuat { get; set; }
       
        [Width(120)]
        public DateTime NgayDc { get; set; }
    }
}