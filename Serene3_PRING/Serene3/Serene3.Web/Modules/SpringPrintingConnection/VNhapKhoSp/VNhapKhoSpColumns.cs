
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.VNhapKhoSp")]
    [BasedOnRow(typeof(Entities.VNhapKhoSpRow), CheckNames = true)]
    public class VNhapKhoSpColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Expr1 { get; set; }
        public Int32 KeyId { get; set; }
        public Int32 MaKh { get; set; }
        [EditLink]
        public String TenKh { get; set; }
        public DateTime NgayNhap { get; set; }
        public Int32 NguoiNhap { get; set; }
        public String GhiChu { get; set; }
        public String MaBtp { get; set; }
        [AlignRight]
        public Int32 SlThuc { get; set; }
        [AlignRight]
        public Int32 SlLoiKh { get; set; }
        [AlignRight]
        public Int32 SlLoiIn { get; set; }
        public String MaMau { get; set; }
        public String MaSize { get; set; }
        public String MaStyle { get; set; }
        public Boolean HangMau { get; set; }
        public Boolean HangBu { get; set; }
        public Int64 CardId { get; set; }
        public String Code { get; set; }
        public String Po { get; set; }
        public String Fepo { get; set; }
        public Int32 BulNo { get; set; }
        public String TableNum { get; set; }
        public String Buy { get; set; }
        public String Style04 { get; set; }
        public String Col { get; set; }
        public String Size { get; set; }
        public String Part { get; set; }
        [AlignRight]
        public Int32 Quantity { get; set; }
    }
}