
namespace Canteen.CantinTHP.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CantinTHP"), Module("CantinTHP"), TableName("[dbo].[tbEmpDayOff]")]
    [DisplayName("Tb Emp Day Off"), InstanceName("Tb Emp Day Off")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class TbEmpDayOffRow : Row, IIdRow, INameRow
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

        [DisplayName("Leave"), Column("LeaveID"), Size(10), ForeignKey("[dbo].[tbRef_LeaveType]", "LeaveID"), LeftJoin("jLeave"), TextualField("LeaveLeaveType")]
        public String LeaveId
        {
            get { return Fields.LeaveId[this]; }
            set { Fields.LeaveId[this] = value; }
        }

        [DisplayName("Leave type"), Column("LeaveType"), Size(10)]
        public Int32? LeaveType
        {
            get { return Fields.LeaveType[this]; }
            set { Fields.LeaveType[this] = value; }
        }

        [DisplayName("Date Change")]
        public DateTime? DateChange
        {
            get { return Fields.DateChange[this]; }
            set { Fields.DateChange[this] = value; }
        }

        [DisplayName("From Date")]
        public DateTime? FromDate
        {
            get { return Fields.FromDate[this]; }
            set { Fields.FromDate[this] = value; }
        }

        [DisplayName("To Date")]
        public DateTime? ToDate
        {
            get { return Fields.ToDate[this]; }
            set { Fields.ToDate[this] = value; }
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

        [DisplayName("Leave Key Id"), Expression("jLeave.[KeyID]")]
        public Int32? LeaveKeyId
        {
            get { return Fields.LeaveKeyId[this]; }
            set { Fields.LeaveKeyId[this] = value; }
        }

        [DisplayName("Leave Leave Type"), Expression("jLeave.[LeaveType]")]
        public String LeaveLeaveType
        {
            get { return Fields.LeaveLeaveType[this]; }
            set { Fields.LeaveLeaveType[this] = value; }
        }

        [DisplayName("Leave Is Long Term"), Expression("jLeave.[IsLong_Term]")]
        public Boolean? LeaveIsLongTerm
        {
            get { return Fields.LeaveIsLongTerm[this]; }
            set { Fields.LeaveIsLongTerm[this] = value; }
        }

        [DisplayName("Leave Active"), Expression("jLeave.[Active]")]
        public Boolean? LeaveActive
        {
            get { return Fields.LeaveActive[this]; }
            set { Fields.LeaveActive[this] = value; }
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

        public TbEmpDayOffRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public StringField EmpId;
            public StringField LeaveId;
            public Int32Field LeaveType;
            public DateTimeField DateChange;
            public DateTimeField FromDate;
            public DateTimeField ToDate;
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

            public Int32Field LeaveKeyId;
            public StringField LeaveLeaveType;
            public BooleanField LeaveIsLongTerm;
            public BooleanField LeaveActive;
        }
    }
}
