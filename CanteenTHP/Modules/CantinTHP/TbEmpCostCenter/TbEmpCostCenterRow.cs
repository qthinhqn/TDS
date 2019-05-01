
namespace Canteen.CantinTHP.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CantinTHP"), Module("CantinTHP"), TableName("[dbo].[tbEmp_CostCenter]")]
    [DisplayName("Tb Emp Cost Center"), InstanceName("Tb Emp Cost Center")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class TbEmpCostCenterRow : Row, IIdRow, INameRow
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

        [DisplayName("Cost Center"), Size(20), NotNull, ForeignKey("[dbo].[tbRef_CostCenter]", "CostCenter"), LeftJoin("jCostCenter"), TextualField("CostCenterRemarks")]
        public String CostCenter
        {
            get { return Fields.CostCenter[this]; }
            set { Fields.CostCenter[this] = value; }
        }

        [DisplayName("Date Change"), NotNull]
        public DateTime? DateChange
        {
            get { return Fields.DateChange[this]; }
            set { Fields.DateChange[this] = value; }
        }

        [DisplayName("Remarks"), Size(255)]
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

        [DisplayName("Cost Center Key Id"), Expression("jCostCenter.[KeyID]")]
        public Int32? CostCenterKeyId
        {
            get { return Fields.CostCenterKeyId[this]; }
            set { Fields.CostCenterKeyId[this] = value; }
        }

        [DisplayName("Cost Center Remarks"), Expression("jCostCenter.[Remarks]")]
        public String CostCenterRemarks
        {
            get { return Fields.CostCenterRemarks[this]; }
            set { Fields.CostCenterRemarks[this] = value; }
        }

        [DisplayName("Cost Center Is Temp"), Expression("jCostCenter.[IsTemp]")]
        public Boolean? CostCenterIsTemp
        {
            get { return Fields.CostCenterIsTemp[this]; }
            set { Fields.CostCenterIsTemp[this] = value; }
        }

        [DisplayName("Cost Center Created Date"), Expression("jCostCenter.[CreatedDate]")]
        public DateTime? CostCenterCreatedDate
        {
            get { return Fields.CostCenterCreatedDate[this]; }
            set { Fields.CostCenterCreatedDate[this] = value; }
        }

        [DisplayName("Cost Center User Create"), Expression("jCostCenter.[UserCreate]")]
        public String CostCenterUserCreate
        {
            get { return Fields.CostCenterUserCreate[this]; }
            set { Fields.CostCenterUserCreate[this] = value; }
        }

        [DisplayName("Cost Center Active"), Expression("jCostCenter.[Active]")]
        public Boolean? CostCenterActive
        {
            get { return Fields.CostCenterActive[this]; }
            set { Fields.CostCenterActive[this] = value; }
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

        public TbEmpCostCenterRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public GuidField KeyId;
            public StringField EmpId;
            public StringField CostCenter;
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

            public StringField StringName;

            public Int32Field CostCenterKeyId;
            public StringField CostCenterRemarks;
            public BooleanField CostCenterIsTemp;
            public DateTimeField CostCenterCreatedDate;
            public StringField CostCenterUserCreate;
            public BooleanField CostCenterActive;
        }
    }
}
