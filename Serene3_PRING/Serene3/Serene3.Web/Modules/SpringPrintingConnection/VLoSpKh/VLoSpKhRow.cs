
namespace Serene3.SpringPrintingConnection.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[vLoSP_KH]")]
    [DisplayName("V Lo Sp Kh"), InstanceName("V Lo Sp Kh")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class VLoSpKhRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id 1"), Column("KeyID_1"), NotNull]
        public Int32? KeyId1
        {
            get { return Fields.KeyId1[this]; }
            set { Fields.KeyId1[this] = value; }
        }

        [DisplayName("Ma Kh"), Column("MaKH")]
        public Int32? MaKh
        {
            get { return Fields.MaKh[this]; }
            set { Fields.MaKh[this] = value; }
        }

        [DisplayName("Ten Kh"), Column("TenKH"), Size(50), QuickSearch]
        public String TenKh
        {
            get { return Fields.TenKh[this]; }
            set { Fields.TenKh[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId1; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.TenKh; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public VLoSpKhRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId1;
            public Int32Field MaKh;
            public StringField TenKh;
		}
    }
}
