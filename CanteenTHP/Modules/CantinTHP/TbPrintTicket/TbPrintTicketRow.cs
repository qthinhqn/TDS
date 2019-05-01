
namespace Canteen.CantinTHP.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CantinTHP"), Module("CantinTHP"), TableName("[dbo].[tbPrintTicket]")]
    [DisplayName("Tb Print Ticket"), InstanceName("Tb Print Ticket")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript]
    public sealed class TbPrintTicketRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Reg Id"), Column("RegID")]
        public Int32? RegId
        {
            get { return Fields.RegId[this]; }
            set { Fields.RegId[this] = value; }
        }

        [DisplayName("D Day"), Column("dDay")]
        public DateTime? DDay
        {
            get { return Fields.DDay[this]; }
            set { Fields.DDay[this] = value; }
        }

        [DisplayName("User Name"), Size(60), QuickSearch]
        public String UserName
        {
            get { return Fields.UserName[this]; }
            set { Fields.UserName[this] = value; }
        }

        [DisplayName("P Num"), Column("pNum")]
        public Int32? PNum
        {
            get { return Fields.PNum[this]; }
            set { Fields.PNum[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.UserName; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TbPrintTicketRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public Int32Field RegId;
            public DateTimeField DDay;
            public StringField UserName;
            public Int32Field PNum;
        }
    }
}
