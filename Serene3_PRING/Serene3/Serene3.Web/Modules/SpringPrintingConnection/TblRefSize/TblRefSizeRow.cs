
namespace Serene3.SpringPrintingConnection.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[tblRef_Size]")]
    [DisplayName("Tbl Ref Size"), InstanceName("Tbl Ref Size")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript]
    public sealed class TblRefSizeRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Ma Size"), Size(50), QuickSearch]
        public String MaSize
        {
            get { return Fields.MaSize[this]; }
            set { Fields.MaSize[this] = value; }
        }

        [DisplayName("Ten Size"), Size(50), QuickSearch]
        public String TenSize
        {
            get { return Fields.TenSize[this]; }
            set { Fields.TenSize[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.TenSize; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TblRefSizeRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public StringField MaSize;
            public StringField TenSize;
		}
    }
}
