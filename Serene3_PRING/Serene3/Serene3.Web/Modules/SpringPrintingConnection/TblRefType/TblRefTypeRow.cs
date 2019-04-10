
namespace Serene3.SpringPrintingConnection.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[tblRef_Type]")]
    [DisplayName("Tbl Ref Type"), InstanceName("Tbl Ref Type")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript]
    public sealed class TblRefTypeRow : Row, IIdRow, INameRow
    {
        [DisplayName("Type Id"), Column("TypeID"), Size(1), PrimaryKey, QuickSearch]
        public String TypeId
        {
            get { return Fields.TypeId[this]; }
            set { Fields.TypeId[this] = value; }
        }

        [DisplayName("Type Name"), Size(20)]
        public String TypeName
        {
            get { return Fields.TypeName[this]; }
            set { Fields.TypeName[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.TypeId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.TypeName; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TblRefTypeRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public StringField TypeId;
            public StringField TypeName;
		}
    }
}
