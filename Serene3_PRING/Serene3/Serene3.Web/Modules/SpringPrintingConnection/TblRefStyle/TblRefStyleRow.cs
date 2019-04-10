
namespace Serene3.SpringPrintingConnection.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[tblRef_Style]")]
    [DisplayName("Tbl Ref Style"), InstanceName("Tbl Ref Style")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript]
    public sealed class TblRefStyleRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Ma Style"), Size(50), QuickSearch]
        public String MaStyle
        {
            get { return Fields.MaStyle[this]; }
            set { Fields.MaStyle[this] = value; }
        }

        [DisplayName("Ten Style"), Size(50), QuickSearch]
        public String TenStyle
        {
            get { return Fields.TenStyle[this]; }
            set { Fields.TenStyle[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.TenStyle; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TblRefStyleRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public StringField MaStyle;
            public StringField TenStyle;
		}
    }
}
