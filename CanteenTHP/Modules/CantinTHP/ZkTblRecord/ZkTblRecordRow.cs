
namespace Canteen.CantinTHP.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CantinTHP"), Module("CantinTHP"), TableName("[dbo].[ZK_tblRecord]")]
    [DisplayName("Zk Tbl Record"), InstanceName("Zk Tbl Record")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript]
    public sealed class ZkTblRecordRow : Row, IIdRow, INameRow
    {
        [DisplayName("User"), Column("UserID"), Size(10), ForeignKey("[dbo].[tbEmp_Card]", "CardID"), LeftJoin("jUser"), QuickSearch, TextualField("UserEmpId")]
        public String UserId
        {
            get { return Fields.UserId[this]; }
            set { Fields.UserId[this] = value; }
        }

        [DisplayName("Ip"), Column("IP"), Size(50)]
        public String Ip
        {
            get { return Fields.Ip[this]; }
            set { Fields.Ip[this] = value; }
        }

        [DisplayName("Ngay Cc"), Column("Ngay_CC"), Size(50)]
        public String NgayCc
        {
            get { return Fields.NgayCc[this]; }
            set { Fields.NgayCc[this] = value; }
        }

        [DisplayName("I Year Id"), Column("iYearID"), Size(4)]
        public String IYearId
        {
            get { return Fields.IYearId[this]; }
            set { Fields.IYearId[this] = value; }
        }

        [DisplayName("I Month Id"), Column("iMonthID"), Size(2)]
        public String IMonthId
        {
            get { return Fields.IMonthId[this]; }
            set { Fields.IMonthId[this] = value; }
        }

        [DisplayName("I Day"), Column("iDay"), Size(2)]
        public String IDay
        {
            get { return Fields.IDay[this]; }
            set { Fields.IDay[this] = value; }
        }

        [DisplayName("I Hour"), Column("iHour"), Size(4)]
        public String IHour
        {
            get { return Fields.IHour[this]; }
            set { Fields.IHour[this] = value; }
        }

        [DisplayName("I Minute"), Column("iMinute"), Size(4)]
        public String IMinute
        {
            get { return Fields.IMinute[this]; }
            set { Fields.IMinute[this] = value; }
        }

        [DisplayName("I Second"), Column("iSecond"), Size(4)]
        public String ISecond
        {
            get { return Fields.ISecond[this]; }
            set { Fields.ISecond[this] = value; }
        }

        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("User Key Id"), Expression("jUser.[KeyID]")]
        public Int32? UserKeyId
        {
            get { return Fields.UserKeyId[this]; }
            set { Fields.UserKeyId[this] = value; }
        }

        [DisplayName("User Emp Id"), Expression("jUser.[EmpID]")]
        public String UserEmpId
        {
            get { return Fields.UserEmpId[this]; }
            set { Fields.UserEmpId[this] = value; }
        }

        [DisplayName("User Date Change"), Expression("jUser.[DateChange]")]
        public DateTime? UserDateChange
        {
            get { return Fields.UserDateChange[this]; }
            set { Fields.UserDateChange[this] = value; }
        }

        [DisplayName("User Remarks"), Expression("jUser.[Remarks]")]
        public String UserRemarks
        {
            get { return Fields.UserRemarks[this]; }
            set { Fields.UserRemarks[this] = value; }
        }

        [DisplayName("User Active"), Expression("jUser.[Active]")]
        public Boolean? UserActive
        {
            get { return Fields.UserActive[this]; }
            set { Fields.UserActive[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.UserId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public ZkTblRecordRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public StringField UserId;
            public StringField Ip;
            public StringField NgayCc;
            public StringField IYearId;
            public StringField IMonthId;
            public StringField IDay;
            public StringField IHour;
            public StringField IMinute;
            public StringField ISecond;
            public Int32Field KeyId;

            public Int32Field UserKeyId;
            public StringField UserEmpId;
            public DateTimeField UserDateChange;
            public StringField UserRemarks;
            public BooleanField UserActive;
        }
    }
}
