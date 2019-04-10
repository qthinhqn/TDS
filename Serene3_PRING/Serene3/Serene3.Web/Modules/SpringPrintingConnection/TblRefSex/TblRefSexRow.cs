
namespace Serene3.SpringPrintingConnection.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[tblRef_Sex]")]
    [DisplayName("Tbl Ref Sex"), InstanceName("Tbl Ref Sex")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript]
    public sealed class TblRefSexRow : Row, IIdRow, INameRow
    {
        [DisplayName("Sex Id"), Column("SexID"), Size(10), PrimaryKey, QuickSearch]
        public String SexId
        {
            get { return Fields.SexId[this]; }
            set { Fields.SexId[this] = value; }
        }

        [DisplayName("Sex Name"), Size(20)]
        public String SexName
        {
            get { return Fields.SexName[this]; }
            set { Fields.SexName[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.SexId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.SexId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TblRefSexRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public StringField SexId;
            public StringField SexName;
		}
    }
}
