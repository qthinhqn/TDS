
namespace Serene3.SpringPrintingConnection.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[tblRef_Mau]")]
    [DisplayName("Tbl Ref Mau"), InstanceName("Tbl Ref Mau")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript]
    public sealed class TblRefMauRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Ma Mau"), Size(50), QuickSearch]
        public String MaMau
        {
            get { return Fields.MaMau[this]; }
            set { Fields.MaMau[this] = value; }
        }

        [DisplayName("Ten Mau"), Size(50), QuickSearch]
        public String TenMau
        {
            get { return Fields.TenMau[this]; }
            set { Fields.TenMau[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.TenMau; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TblRefMauRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public StringField MaMau;
            public StringField TenMau;
		}
    }
}
