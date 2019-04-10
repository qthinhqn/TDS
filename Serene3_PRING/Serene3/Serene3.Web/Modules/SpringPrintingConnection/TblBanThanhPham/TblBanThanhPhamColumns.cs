
namespace Serene3.SpringPrintingConnection.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SpringPrintingConnection.TblBanThanhPham")]
    [BasedOnRow(typeof(Entities.TblBanThanhPhamRow), CheckNames = true)]
    public class TblBanThanhPhamColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //public Int32 KeyId { get; set; }
        [EditLink, Width(300)]
        public String MotaBtp { get; set; }
        [EditLink, Width(150)]
        public String DonViTinh { get; set; }
        [Width(120)]
        public DateTime NgayTao { get; set; }
        [Width(150)]
        public Boolean Status { get; set; }
    }
}