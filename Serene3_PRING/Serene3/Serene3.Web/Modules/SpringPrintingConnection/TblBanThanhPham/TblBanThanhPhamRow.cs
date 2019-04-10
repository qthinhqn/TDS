
namespace Serene3.SpringPrintingConnection.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[tblBanThanhPham]")]
    [DisplayName("Tbl Ban Thanh Pham"), InstanceName("Tbl Ban Thanh Pham")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript]
    public sealed class TblBanThanhPhamRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Mota Btp"), Column("MotaBTP"), Size(50), QuickSearch]
        public String MotaBtp
        {
            get { return Fields.MotaBtp[this]; }
            set { Fields.MotaBtp[this] = value; }
        }

        [DisplayName("Don Vi Tinh"), Size(50), QuickSearch]
        public String DonViTinh
        {
            get { return Fields.DonViTinh[this]; }
            set { Fields.DonViTinh[this] = value; }
        }

        [DisplayName("Ngay Tao")]
        public DateTime? NgayTao
        {
            get { return Fields.NgayTao[this]; }
            set { Fields.NgayTao[this] = value; }
        }

        [DisplayName("Status")]
        public Boolean? Status
        {
            get { return Fields.Status[this]; }
            set { Fields.Status[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.MotaBtp; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TblBanThanhPhamRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public StringField MotaBtp;
            public StringField DonViTinh;
            public DateTimeField NgayTao;
            public BooleanField Status;
		}
    }
}
