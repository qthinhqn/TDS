
namespace Canteen.CantinTHP.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CantinTHP"), Module("CantinTHP"), TableName("[dbo].[tbEmp_Canteen]")]
    [DisplayName("Tb Emp Canteen"), InstanceName("Tb Emp Canteen")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class TbEmpCanteenRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Emp"), Column("EmpID"), Size(25), ForeignKey("[dbo].[tbEmployee]", "EmployeeID"), LeftJoin("jEmp"), QuickSearch, TextualField("EmpEmployeeCost")]
        public String EmpId
        {
            get { return Fields.EmpId[this]; }
            set { Fields.EmpId[this] = value; }
        }

        [DisplayName("Canteen"), Column("CanteenID"), Size(10), ForeignKey("[dbo].[tbRef_Canteen]", "CanteenID"), LeftJoin("jCanteen"), TextualField("CanteenCanteenName")]
        public String CanteenId
        {
            get { return Fields.CanteenId[this]; }
            set { Fields.CanteenId[this] = value; }
        }

        [DisplayName("Date Change")]
        public DateTime? DateChange
        {
            get { return Fields.DateChange[this]; }
            set { Fields.DateChange[this] = value; }
        }

        [DisplayName("Active")]
        public Boolean? Active
        {
            get { return Fields.Active[this]; }
            set { Fields.Active[this] = value; }
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

        [DisplayName("Canteen Key Id"), Expression("jCanteen.[KeyID]")]
        public Int32? CanteenKeyId
        {
            get { return Fields.CanteenKeyId[this]; }
            set { Fields.CanteenKeyId[this] = value; }
        }

        [DisplayName("Canteen Canteen Name"), Expression("jCanteen.[CanteenName]")]
        public String CanteenCanteenName
        {
            get { return Fields.CanteenCanteenName[this]; }
            set { Fields.CanteenCanteenName[this] = value; }
        }

        [DisplayName("Canteen Contact Person"), Expression("jCanteen.[ContactPerson]")]
        public String CanteenContactPerson
        {
            get { return Fields.CanteenContactPerson[this]; }
            set { Fields.CanteenContactPerson[this] = value; }
        }

        [DisplayName("Canteen Phone Num"), Expression("jCanteen.[PhoneNum]")]
        public String CanteenPhoneNum
        {
            get { return Fields.CanteenPhoneNum[this]; }
            set { Fields.CanteenPhoneNum[this] = value; }
        }

        [DisplayName("Canteen Remarks"), Expression("jCanteen.[Remarks]")]
        public String CanteenRemarks
        {
            get { return Fields.CanteenRemarks[this]; }
            set { Fields.CanteenRemarks[this] = value; }
        }

        [DisplayName("Canteen Active"), Expression("jCanteen.[Active]")]
        public Boolean? CanteenActive
        {
            get { return Fields.CanteenActive[this]; }
            set { Fields.CanteenActive[this] = value; }
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

        public TbEmpCanteenRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public StringField EmpId;
            public StringField CanteenId;
            public DateTimeField DateChange;
            public BooleanField Active;

            public Int32Field EmpKeyId;
            public StringField EmpFirstName;
            public StringField EmpLastName;
            public StringField EmpEmployeeName;
            public StringField EmpSexId;
            public DateTimeField EmpLeftDate;
            public DateTimeField EmpStartDate;
            public BooleanField EmpActive;

            public StringField StringName;

            public Int32Field CanteenKeyId;
            public StringField CanteenCanteenName;
            public StringField CanteenContactPerson;
            public StringField CanteenPhoneNum;
            public StringField CanteenRemarks;
            public BooleanField CanteenActive;
        }
    }
}
