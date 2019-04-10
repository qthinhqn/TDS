
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblLenChuyenIn_ChiTiet")]
    [BasedOnRow(typeof(Entities.TblLenChuyenIn_ChiTietRow), CheckNames = true)]
    public class TblLenChuyenIn_ChiTietColumns
    {
        //[EditLink, AlignCenter]
       // public Int32 KeyId { get; set; }
        //[EditLink, Width(120)]
        //[LookupEditor(typeof(Entities.TblBo_BTPRow))]
        //public Int32 MotaBTP { get; set; }

        [EditLink,Width(100)]
        public DateTime Ngay { get; set; }
        [EditLink, Width(200), LookupEditor(typeof(Entities.TblBo_BTPRow))]
        public String CT_MaBTP { get; set; }
        [EditLink, Width(120)]
        public String CT_MaMau { get; set; }
        [EditLink, Width(120)]
        public String CT_MaSize { get; set; }
        [Width(120)]
        public String CT_MaStyle { get; set; }
        [Width(120), AlignRight]
        public Int32 CT_SL_Thuc { get; set; }
        [Width(120), AlignRight]
        public Int32 CT_SL_Loi_KH { get; set; }
        [Width(120), AlignRight]
        public Int32 CT_SL_Loi_In { get; set; }
        //    [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //    public Int32 KeyId { get; set; }
        //    public String MaBoCode { get; set; }
        //    public DateTime Ngay { get; set; }
        //    public Boolean Status { get; set; }
        //    public Int32 MaLenChuyen { get; set; }
        }
    }