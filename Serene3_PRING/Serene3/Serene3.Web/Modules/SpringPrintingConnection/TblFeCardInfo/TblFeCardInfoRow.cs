
namespace Serene3.SpringPrintingConnection.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[tblFE_CardInfo]")]
    [DisplayName("Tbl Fe Card Info"), InstanceName("Tbl Fe Card Info")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class TblFeCardInfoRow : Row, IIdRow, INameRow
    {
        [DisplayName("Rec Id"), Column("RecID"), PrimaryKey]
        public Guid? RecId
        {
            get { return Fields.RecId[this]; }
            set { Fields.RecId[this] = value; }
        }

        [DisplayName("Card Id"), Column("CardID"), QuickSearch(SearchType.StartsWith)]
        public Int64? CardId
        {
            get { return Fields.CardId[this]; }
            set { Fields.CardId[this] = value; }
        }

        [DisplayName("Ref Bar Code"), Size(25), QuickSearch(SearchType.StartsWith)]
        public String RefBarCode
        {
            get { return Fields.RefBarCode[this]; }
            set { Fields.RefBarCode[this] = value; }
        }

        [DisplayName("Create Time")]
        public DateTime? CreateTime
        {
            get { return Fields.CreateTime[this]; }
            set { Fields.CreateTime[this] = value; }
        }

        [DisplayName("Import Time")]
        public DateTime? ImportTime
        {
            get { return Fields.ImportTime[this]; }
            set { Fields.ImportTime[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.RecId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.RefBarCode; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TblFeCardInfoRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public GuidField RecId;
            public Int64Field CardId;
            public StringField RefBarCode;
            public DateTimeField CreateTime;
            public DateTimeField ImportTime;
		}
    }
}
