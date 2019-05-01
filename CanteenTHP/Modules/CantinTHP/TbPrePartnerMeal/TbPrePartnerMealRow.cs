
namespace Canteen.CantinTHP.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CantinTHP"), Module("CantinTHP"), TableName("[dbo].[tbPre_PartnerMeal]")]
    [DisplayName("Tb Pre Partner Meal"), InstanceName("Tb Pre Partner Meal")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript]
    public sealed class TbPrePartnerMealRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Partner Name"), Size(255), NotNull, QuickSearch]
        public String PartnerName
        {
            get { return Fields.PartnerName[this]; }
            set { Fields.PartnerName[this] = value; }
        }

        [DisplayName("Contact Name"), Size(255)]
        public String ContactName
        {
            get { return Fields.ContactName[this]; }
            set { Fields.ContactName[this] = value; }
        }

        [DisplayName("D Date"), Column("dDate"), NotNull]
        public DateTime? DDate
        {
            get { return Fields.DDate[this]; }
            set { Fields.DDate[this] = value; }
        }

        [DisplayName("Phone"), Size(50)]
        public String Phone
        {
            get { return Fields.Phone[this]; }
            set { Fields.Phone[this] = value; }
        }

        [DisplayName("Remarks"), Size(255)]
        public String Remarks
        {
            get { return Fields.Remarks[this]; }
            set { Fields.Remarks[this] = value; }
        }

        [DisplayName("Employee Id"), Column("EmployeeID"), Size(25)]
        public String EmployeeId
        {
            get { return Fields.EmployeeId[this]; }
            set { Fields.EmployeeId[this] = value; }
        }

        [DisplayName("Created Date")]
        public DateTime? CreatedDate
        {
            get { return Fields.CreatedDate[this]; }
            set { Fields.CreatedDate[this] = value; }
        }

        [DisplayName("User Create"), Size(25)]
        public String UserCreate
        {
            get { return Fields.UserCreate[this]; }
            set { Fields.UserCreate[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.PartnerName; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TbPrePartnerMealRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public StringField PartnerName;
            public StringField ContactName;
            public DateTimeField DDate;
            public StringField Phone;
            public StringField Remarks;
            public StringField EmployeeId;
            public DateTimeField CreatedDate;
            public StringField UserCreate;
        }
    }
}
