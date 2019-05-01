
namespace Canteen.CantinTHP.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CantinTHP"), Module("CantinTHP"), TableName("[dbo].[tbEmp_Company]")]
    [DisplayName("Tb Emp Company"), InstanceName("Tb Emp Company")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class TbEmpCompanyRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), PrimaryKey]
        public Guid? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Emp"), Column("EmpID"), Size(25), NotNull, ForeignKey("[dbo].[tbEmployee]", "EmployeeID"), LeftJoin("jEmp"), QuickSearch, TextualField("EmpEmployeeCost")]
        public String EmpId
        {
            get { return Fields.EmpId[this]; }
            set { Fields.EmpId[this] = value; }
        }

        [DisplayName("Company Key"), Size(10), NotNull, ForeignKey("[dbo].[tbRef_Company]", "CompanyKey"), LeftJoin("jCompanyKey"), TextualField("CompanyKeyCompanyName")]
        public String CompanyKey
        {
            get { return Fields.CompanyKey[this]; }
            set { Fields.CompanyKey[this] = value; }
        }

        [DisplayName("Date Change"), NotNull]
        public DateTime? DateChange
        {
            get { return Fields.DateChange[this]; }
            set { Fields.DateChange[this] = value; }
        }

        [DisplayName("Remarks"), Size(250)]
        public String Remarks
        {
            get { return Fields.Remarks[this]; }
            set { Fields.Remarks[this] = value; }
        }

        [DisplayName("Emp Key Id"), Expression("jEmp.[KeyID]")]
        public Int32? EmpKeyId
        {
            get { return Fields.EmpKeyId[this]; }
            set { Fields.EmpKeyId[this] = value; }
        }

        [DisplayName("Emp First Name"), Expression("jEmp.[FirstName]")]
        public String EmpFirstName
        {
            get { return Fields.EmpFirstName[this]; }
            set { Fields.EmpFirstName[this] = value; }
        }

        [DisplayName("Emp Last Name"), Expression("jEmp.[LastName]")]
        public String EmpLastName
        {
            get { return Fields.EmpLastName[this]; }
            set { Fields.EmpLastName[this] = value; }
        }

        [DisplayName("Emp Employee Name"), Expression("jEmp.[EmployeeName]")]
        public String EmpEmployeeName
        {
            get { return Fields.EmpEmployeeName[this]; }
            set { Fields.EmpEmployeeName[this] = value; }
        }

        [DisplayName("Emp Sex Id"), Expression("jEmp.[SexID]")]
        public String EmpSexId
        {
            get { return Fields.EmpSexId[this]; }
            set { Fields.EmpSexId[this] = value; }
        }

        [DisplayName("Emp Left Date"), Expression("jEmp.[LeftDate]")]
        public DateTime? EmpLeftDate
        {
            get { return Fields.EmpLeftDate[this]; }
            set { Fields.EmpLeftDate[this] = value; }
        }

        [DisplayName("Emp Start Date"), Expression("jEmp.[StartDate]")]
        public DateTime? EmpStartDate
        {
            get { return Fields.EmpStartDate[this]; }
            set { Fields.EmpStartDate[this] = value; }
        }

        [DisplayName("Emp Active"), Expression("jEmp.[Active]")]
        public Boolean? EmpActive
        {
            get { return Fields.EmpActive[this]; }
            set { Fields.EmpActive[this] = value; }
        }

        [DisplayName("String Name")]
        [Expression("CONCAT('[' , jEmp.[EmployeeId] , '] ' , jEmp.[EmployeeName])")]
        public String StringName
        {
            get { return Fields.StringName[this]; }
            set { Fields.StringName[this] = value; }
        }

        [DisplayName("Company Key Key Id"), Expression("jCompanyKey.[KeyID]")]
        public Int32? CompanyKeyKeyId
        {
            get { return Fields.CompanyKeyKeyId[this]; }
            set { Fields.CompanyKeyKeyId[this] = value; }
        }

        [DisplayName("Company Key Company Name"), Expression("jCompanyKey.[CompanyName]")]
        public String CompanyKeyCompanyName
        {
            get { return Fields.CompanyKeyCompanyName[this]; }
            set { Fields.CompanyKeyCompanyName[this] = value; }
        }

        [DisplayName("Company Key Company Name Eng"), Expression("jCompanyKey.[CompanyName_Eng]")]
        public String CompanyKeyCompanyNameEng
        {
            get { return Fields.CompanyKeyCompanyNameEng[this]; }
            set { Fields.CompanyKeyCompanyNameEng[this] = value; }
        }

        [DisplayName("Company Key Remarks"), Expression("jCompanyKey.[Remarks]")]
        public String CompanyKeyRemarks
        {
            get { return Fields.CompanyKeyRemarks[this]; }
            set { Fields.CompanyKeyRemarks[this] = value; }
        }

        [DisplayName("Company Key Active"), Expression("jCompanyKey.[Active]")]
        public Boolean? CompanyKeyActive
        {
            get { return Fields.CompanyKeyActive[this]; }
            set { Fields.CompanyKeyActive[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.EmpId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TbEmpCompanyRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public GuidField KeyId;
            public StringField EmpId;
            public StringField CompanyKey;
            public DateTimeField DateChange;
            public StringField Remarks;

            public Int32Field EmpKeyId;
            public StringField EmpFirstName;
            public StringField EmpLastName;
            public StringField EmpEmployeeName;
            public StringField EmpSexId;
            public DateTimeField EmpLeftDate;
            public DateTimeField EmpStartDate;
            public BooleanField EmpActive;

            public Int32Field CompanyKeyKeyId;
            public StringField CompanyKeyCompanyName;
            public StringField CompanyKeyCompanyNameEng;
            public StringField CompanyKeyRemarks;
            public BooleanField CompanyKeyActive;

            public StringField StringName;
        }
    }
}
