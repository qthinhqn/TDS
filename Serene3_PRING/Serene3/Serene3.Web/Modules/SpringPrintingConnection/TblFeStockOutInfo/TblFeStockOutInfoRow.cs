
namespace Serene3.SpringPrintingConnection.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("SpringPrintingConnection"), Module("SpringPrintingConnection"), TableName("[dbo].[tblFE_StockOutInfo]")]
    [DisplayName("Tbl Fe Stock Out Info"), InstanceName("Tbl Fe Stock Out Info")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class TblFeStockOutInfoRow : Row, IIdRow, INameRow
    {
        [DisplayName("Rec Id"), Column("RecID"), PrimaryKey]
        public Guid? RecId
        {
            get { return Fields.RecId[this]; }
            set { Fields.RecId[this] = value; }
        }

        [DisplayName("Rfid Output Id"), Column("RFIDOutputID")]
        public Int32? RfidOutputId
        {
            get { return Fields.RfidOutputId[this]; }
            set { Fields.RfidOutputId[this] = value; }
        }

        [DisplayName("D Date"), Column("dDate")]
        public DateTime? DDate
        {
            get { return Fields.DDate[this]; }
            set { Fields.DDate[this] = value; }
        }

        [DisplayName("Fty"), Column("FTY"), Size(50)]
        public String Fty
        {
            get { return Fields.Fty[this]; }
            set { Fields.Fty[this] = value; }
        }

        [DisplayName("Po"), Column("PO"), Size(50)]
        public String Po
        {
            get { return Fields.Po[this]; }
            set { Fields.Po[this] = value; }
        }

        [DisplayName("Fepo"), Column("FEPO"), Size(50)]
        public String Fepo
        {
            get { return Fields.Fepo[this]; }
            set { Fields.Fepo[this] = value; }
        }

        [DisplayName("Card Id"), Column("CardID"), QuickSearch(SearchType.StartsWith)]
        public Int64? CardId
        {
            get { return Fields.CardId[this]; }
            set { Fields.CardId[this] = value; }
        }

        [DisplayName("Code"), Size(25), QuickSearch(SearchType.StartsWith)]
        public String Code
        {
            get { return Fields.Code[this]; }
            set { Fields.Code[this] = value; }
        }

        [DisplayName("Bul No")]
        public Int32? BulNo
        {
            get { return Fields.BulNo[this]; }
            set { Fields.BulNo[this] = value; }
        }

        [DisplayName("Table Num"), Size(50)]
        public String TableNum
        {
            get { return Fields.TableNum[this]; }
            set { Fields.TableNum[this] = value; }
        }

        [DisplayName("Buy"), Size(50)]
        public String Buy
        {
            get { return Fields.Buy[this]; }
            set { Fields.Buy[this] = value; }
        }

        [DisplayName("Style04"), Size(50), QuickSearch]
        public String Style04
        {
            get { return Fields.Style04[this]; }
            set { Fields.Style04[this] = value; }
        }

        [DisplayName("Col"), Column("COL"), Size(50)]
        public String Col
        {
            get { return Fields.Col[this]; }
            set { Fields.Col[this] = value; }
        }

        [DisplayName("Size"), Size(50)]
        public String Size
        {
            get { return Fields.Size[this]; }
            set { Fields.Size[this] = value; }
        }

        [DisplayName("Part"), Size(50), QuickSearch]
        public String Part
        {
            get { return Fields.Part[this]; }
            set { Fields.Part[this] = value; }
        }

        [DisplayName("Op No"), Column("OPNo"), Size(50)]
        public String OpNo
        {
            get { return Fields.OpNo[this]; }
            set { Fields.OpNo[this] = value; }
        }

        [DisplayName("Op Name"), Column("OPName"), Size(50)]
        public String OpName
        {
            get { return Fields.OpName[this]; }
            set { Fields.OpName[this] = value; }
        }

        [DisplayName("Quantity")]
        public Int32? Quantity
        {
            get { return Fields.Quantity[this]; }
            set { Fields.Quantity[this] = value; }
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
            get { return Fields.Fty; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TblFeStockOutInfoRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public GuidField RecId;
            public Int32Field RfidOutputId;
            public DateTimeField DDate;
            public StringField Fty;
            public StringField Po;
            public StringField Fepo;
            public Int64Field CardId;
            public StringField Code;
            public Int32Field BulNo;
            public StringField TableNum;
            public StringField Buy;
            public StringField Style04;
            public StringField Col;
            public StringField Size;
            public StringField Part;
            public StringField OpNo;
            public StringField OpName;
            public Int32Field Quantity;
            public DateTimeField ImportTime;
		}
    }
}
