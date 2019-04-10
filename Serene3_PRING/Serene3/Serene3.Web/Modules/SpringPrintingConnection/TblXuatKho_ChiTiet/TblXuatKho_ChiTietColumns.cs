
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblXuatKho_ChiTiet")]
    [BasedOnRow(typeof(Entities.TblXuatKho_ChiTietRow), CheckNames = true)]
    public class TblXuatKho_ChiTietColumns
    {
    //    [EditLink,  AlignCenter]
    //    public Int32 KeyId { get; set; }
        //[EditLink, Width(120)]
        //public Int32 MaBo { get; set; }
        [EditLink, Width(100)]
        public DateTime Ngay { get; set; }
        //[Width(80)]
        //public Boolean Status { get; set; }
        //[Width(120)]
        //public String MaPhieuXuatSoPhieu { get; set; }

        [EditLink, Width(200)]
        public String CT_MaBTP { get; set; }
        [EditLink, Width(120)]
        public String CT_MaMau { get; set; }
        [Width(120)]
        public String CT_MaSize { get; set; }
        [EditLink, Width(120)]
        public String CT_MaStyle { get; set; }
        [Width(120), AlignRight]
        public Int32 CT_SL_Thuc { get; set; }
        [Width(120), AlignRight]
        public Int32 CT_SL_Loi_KH { get; set; }
        [Width(120), AlignRight]
        public Int32 CT_SL_Loi_In { get; set; }
    }
}