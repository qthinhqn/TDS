
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblBo_BTP")]
    [BasedOnRow(typeof(Entities.TblBo_BTPRow), CheckNames = true)]
    public class TblBo_BTPColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //public Int32 KeyId { get; set; }
        [EditLink, Width(100), ReadOnly(true)]
        public String MaLo { get; set; }
        //[EditLink, Width(250)]
        //public String TenKH { get; set; }
        [EditLink, Width(100)]
        public String CardId { get; set; }
        [EditLink, Width(150)]
        public String MaBtpMotaBtp { get; set; }
        [Width(100)]
        public String MaMauTenMau { get; set; }
        [Width(100)]
        public String MaSizeTenSize { get; set; }
        [Width(100)]
        public String MaStyleTenStyle { get; set; }
        [Width(100), AlignRight]
        public Int32 SlThuc { get; set; }
        [Width(100), AlignRight]
        public Int32 SlLoiKh { get; set; }
        //[Width(100)]
        //public Int32 SlLoiIn { get; set; }
        //[Width(100)]
        //public Int32 MaIn { get; set; }
        //[Width(100)]
        //public Int32 MaOut { get; set; }
        //[Width(100)]
        //public Int32 MaLenChuyen { get; set; }
        //[Width(100)]
        //public Int32 MaXuongChuyen { get; set; }

        //[Width(80)]
        //public Boolean HangMau { get; set; }
        //[Width(80)]
        //public Boolean HangBu { get; set; }
        [Width(120)]
        public String MaTypeTenType { get; set; }
        //[Width(150)]
        //public String MaHdNoiDung { get; set; }
    }
}