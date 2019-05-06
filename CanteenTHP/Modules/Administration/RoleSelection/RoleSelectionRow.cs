
namespace Canteen.Administration.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), Module("Administration"), TableName("[dbo].[RoleSelection]")]
    [DisplayName("Role Selection"), InstanceName("Role Selection")]
    [ReadPermission(PermissionKeys.Security)]
    [ModifyPermission(PermissionKeys.Security)]
    [LeftJoin("ed", "v_EmployeeInfoCurrent", "ed.[EmployeeID] = t0.[EmpID]", RowType = typeof(CantinTHP.Entities.VEmployeeInfoCurrentRow), TitlePrefix = "")]

    public sealed class RoleSelectionRow : Row, IIdRow, INameRow
    {
        [DisplayName("Role Selection Id"), Identity]
        public Int64? RoleSelectionId
        {
            get { return Fields.RoleSelectionId[this]; }
            set { Fields.RoleSelectionId[this] = value; }
        }

        [DisplayName("Role"), NotNull, ForeignKey("[dbo].[Roles]", "RoleId"), LeftJoin("jRole"), TextualField("RoleRoleName")]
        public Int32? RoleId
        {
            get { return Fields.RoleId[this]; }
            set { Fields.RoleId[this] = value; }
        }

        [DisplayName("Emp"), Column("EmpID"), Size(25), NotNull]
        public String EmpId
        {
            get { return Fields.EmpId[this]; }
            set { Fields.EmpId[this] = value; }
        }

        [DisplayName("Role Role Name"), Expression("jRole.[RoleName]")]
        public String RoleRoleName
        {
            get { return Fields.RoleRoleName[this]; }
            set { Fields.RoleRoleName[this] = value; }
        }

        [DisplayName("Company Key"), Expression("ed.[CompanyName]")]
        public String CompanyKey
        {
            get { return Fields.CompanyKey[this]; }
            set { Fields.CompanyKey[this] = value; }
        }

        [DisplayName("LastName"), Expression("ed.[LastName]")]
        public String LastName
        {
            get { return Fields.LastName[this]; }
            set { Fields.LastName[this] = value; }
        }

        [DisplayName("FirstName"), Expression("ed.[FirstName]")]
        public String FirstName
        {
            get { return Fields.FirstName[this]; }
            set { Fields.FirstName[this] = value; }
        }

        [DisplayName("Employee Name"), Expression("ed.[EmployeeName]")]
        public String EmployeeName
        {
            get { return Fields.EmployeeName[this]; }
            set { Fields.EmployeeName[this] = value; }
        }

        [DisplayName("Sex Id"), Expression("ed.[SexId]")]
        public String SexId
        {
            get { return Fields.SexId[this]; }
            set { Fields.SexId[this] = value; }
        }

        [DisplayName("Left Date"), Expression("ed.[LeftDate]")]
        public DateTime? LeftDate
        {
            get { return Fields.LeftDate[this]; }
            set { Fields.LeftDate[this] = value; }
        }

        [DisplayName("Start Date"), Expression("ed.[StartDate]")]
        public DateTime? StartDate
        {
            get { return Fields.StartDate[this]; }
            set { Fields.StartDate[this] = value; }
        }

        [DisplayName("Dep Key"), Expression("ed.[DepName]")]
        public String DepKey
        {
            get { return Fields.DepKey[this]; }
            set { Fields.DepKey[this] = value; }
        }

        [DisplayName("Is Manager"), Expression("ed.[IsManager]")]
        public Boolean? IsManager
        {
            get { return Fields.IsManager[this]; }
            set { Fields.IsManager[this] = value; }
        }

        [DisplayName("Canteen"), Expression("ed.[CanteenName]")]
        public String CanteenId
        {
            get { return Fields.CanteenId[this]; }
            set { Fields.CanteenId[this] = value; }
        }

        [DisplayName("Cost Center"), Expression("ed.[CostCenter]")]
        public String CostCenter
        {
            get { return Fields.CostCenter[this]; }
            set { Fields.CostCenter[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.RoleSelectionId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.EmpId; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public RoleSelectionRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field RoleSelectionId;
            public Int32Field RoleId;
            public StringField EmpId;

            public StringField RoleRoleName;

            public StringField FirstName;
            public StringField LastName;
            public StringField EmployeeName;
            public StringField SexId;
            public DateTimeField LeftDate;
            public DateTimeField StartDate;
            public StringField CompanyKey;
            public StringField DepKey;
            public BooleanField IsManager;
            public StringField CanteenId;
            public StringField CostCenter;

        }
    }
}
