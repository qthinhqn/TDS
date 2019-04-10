
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblHopDongDieuChinh")]
    [BasedOnRow(typeof(Entities.TblHopDongDieuChinhRow), CheckNames = true)]
    public class TblHopDongDieuChinhColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 KeyId { get; set; }
        [EditLink, Width(100)]
        public Int32 MaChiTietHd { get; set; }
        [Width(100), AlignRight]
        public Int32 SlNhan { get; set; }
        [Width(100), AlignRight]
        public Int32 SlNhanHu { get; set; }
        [Width(100), AlignRight]
        public Int32 SlInHu { get; set; }
        [Width(100), AlignRight]
        public Int32 SlXuat { get; set; }
        [Width(150)]
        public String MaNvHoTen { get; set; }
        [Width(100)]
        public DateTime NgayDc { get; set; }
    }
}