
namespace Serene3.SpringPrintingConnection.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SpringPrintingConnection.TblHopDongChiTiet")]
    [BasedOnRow(typeof(Entities.TblHopDongChiTietRow), CheckNames = true)]
    public class TblHopDongChiTietForm
    {
        [Category("PO Detail")]
        public Int32 KeyId { get; set; }
        //[LookupEditor(typeof(Entities.TblHopDongRow)), QuickFilter]
        //public Int32 MaHd { get; set; }
        [LookupEditor(typeof(Entities.TblBanThanhPhamRow)), QuickFilter]
        public Int32 MaBtp { get; set; }
        [LookupEditor(typeof(Entities.TblRefMauRow)), QuickFilter]
        public Int32 MaMau { get; set; }
        [LookupEditor(typeof(Entities.TblRefSizeRow)), QuickFilter]
        public Int32 MaSize { get; set; }
        [LookupEditor(typeof(Entities.TblRefStyleRow)), QuickFilter]
        public Int32 MaStyle { get; set; }
        public Int32 SoLuong { get; set; }
        public Double DonGia { get; set; }
        public Double ThanhTien { get; set; }

        //[Category("Adjust Detail")]
        //[TblHopDongDieuChinhsEditor]
        //public List<Entities.TblHopDongDieuChinhRow> AdjDetailList { get; set; }
    }
}