
namespace Canteen.CantinTHP.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CantinTHP"), Module("CantinTHP"), TableName("[dbo].[v_EmployeeSelection]")]
    [DisplayName("V Employee Selection"), InstanceName("V Employee Selection")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class VEmployeeSelectionRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), NotNull]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Employee Id"), Column("EmployeeID"), Size(25), NotNull, QuickSearch]
        public String EmployeeId
        {
            get { return Fields.EmployeeId[this]; }
            set { Fields.EmployeeId[this] = value; }
        }

        [DisplayName("First Name"), Size(20)]
        public String FirstName
        {
            get { return Fields.FirstName[this]; }
            set { Fields.FirstName[this] = value; }
        }

        [DisplayName("Last Name"), Size(40)]
        public String LastName
        {
            get { return Fields.LastName[this]; }
            set { Fields.LastName[this] = value; }
        }

        [DisplayName("Employee Name"), Size(60)]
        public String EmployeeName
        {
            get { return Fields.EmployeeName[this]; }
            set { Fields.EmployeeName[this] = value; }
        }

        [DisplayName("Sex Id"), Column("SexID"), Size(10)]
        public String SexId
        {
            get { return Fields.SexId[this]; }
            set { Fields.SexId[this] = value; }
        }

        [DisplayName("Left Date")]
        public DateTime? LeftDate
        {
            get { return Fields.LeftDate[this]; }
            set { Fields.LeftDate[this] = value; }
        }

        [DisplayName("Active")]
        public Boolean? Active
        {
            get { return Fields.Active[this]; }
            set { Fields.Active[this] = value; }
        }

        [DisplayName("Start Date")]
        public DateTime? StartDate
        {
            get { return Fields.StartDate[this]; }
            set { Fields.StartDate[this] = value; }
        }

        [DisplayName("Company Key"), Size(10)]
        public String CompanyKey
        {
            get { return Fields.CompanyKey[this]; }
            set { Fields.CompanyKey[this] = value; }
        }

        [DisplayName("Company Name"), Size(255)]
        public String CompanyName
        {
            get { return Fields.CompanyName[this]; }
            set { Fields.CompanyName[this] = value; }
        }

        [DisplayName("Dep Key"), Size(10)]
        public String DepKey
        {
            get { return Fields.DepKey[this]; }
            set { Fields.DepKey[this] = value; }
        }

        [DisplayName("Dep Name"), Size(100)]
        public String DepName
        {
            get { return Fields.DepName[this]; }
            set { Fields.DepName[this] = value; }
        }

        [DisplayName("Is Manager")]
        public Boolean? IsManager
        {
            get { return Fields.IsManager[this]; }
            set { Fields.IsManager[this] = value; }
        }

        [DisplayName("Canteen Id"), Column("CanteenID"), Size(10)]
        public String CanteenId
        {
            get { return Fields.CanteenId[this]; }
            set { Fields.CanteenId[this] = value; }
        }

        [DisplayName("Canteen Name"), Size(255)]
        public String CanteenName
        {
            get { return Fields.CanteenName[this]; }
            set { Fields.CanteenName[this] = value; }
        }

        [DisplayName("Cost Center"), Size(20)]
        public String CostCenter
        {
            get { return Fields.CostCenter[this]; }
            set { Fields.CostCenter[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.EmployeeId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.EmployeeId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public VEmployeeSelectionRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public StringField EmployeeId;
            public StringField FirstName;
            public StringField LastName;
            public StringField EmployeeName;
            public StringField SexId;
            public DateTimeField LeftDate;
            public BooleanField Active;
            public DateTimeField StartDate;
            public StringField CompanyKey;
            public StringField CompanyName;
            public StringField DepKey;
            public StringField DepName;
            public BooleanField IsManager;
            public StringField CanteenId;
            public StringField CanteenName;
            public StringField CostCenter;
        }
    }
}
