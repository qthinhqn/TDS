
namespace Canteen.CantinTHP.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CantinTHP"), Module("CantinTHP"), TableName("[dbo].[tbEmp_CostTemp]")]
    [DisplayName("Tb Emp Cost Temp"), InstanceName("Tb Emp Cost Temp")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class TbEmpCostTempRow : Row, IIdRow, INameRow
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

        [DisplayName("Cost Id"), Column("CostID"), Size(10)]
        public String CostId
        {
            get { return Fields.CostId[this]; }
            set { Fields.CostId[this] = value; }
        }

        [DisplayName("D Day"), Column("dDay")]
        public DateTime? DDay
        {
            get { return Fields.DDay[this]; }
            set { Fields.DDay[this] = value; }
        }

        [DisplayName("Shift"), Column("ShiftID"), Size(10), ForeignKey("[dbo].[tbRef_Shift]", "ShiftID"), LeftJoin("jShift"), TextualField("ShiftShiftName")]
        public String ShiftId
        {
            get { return Fields.ShiftId[this]; }
            set { Fields.ShiftId[this] = value; }
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

        [DisplayName("Shift Key Id"), Expression("jShift.[KeyID]")]
        public Int32? ShiftKeyId
        {
            get { return Fields.ShiftKeyId[this]; }
            set { Fields.ShiftKeyId[this] = value; }
        }

        [DisplayName("Shift Shift Name"), Expression("jShift.[ShiftName]")]
        public String ShiftShiftName
        {
            get { return Fields.ShiftShiftName[this]; }
            set { Fields.ShiftShiftName[this] = value; }
        }

        [DisplayName("Shift Begin Time"), Expression("jShift.[BeginTime]")]
        public DateTime? ShiftBeginTime
        {
            get { return Fields.ShiftBeginTime[this]; }
            set { Fields.ShiftBeginTime[this] = value; }
        }

        [DisplayName("Shift End Time"), Expression("jShift.[EndTime]")]
        public DateTime? ShiftEndTime
        {
            get { return Fields.ShiftEndTime[this]; }
            set { Fields.ShiftEndTime[this] = value; }
        }

        [DisplayName("Shift Active"), Expression("jShift.[Active]")]
        public Boolean? ShiftActive
        {
            get { return Fields.ShiftActive[this]; }
            set { Fields.ShiftActive[this] = value; }
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

        public TbEmpCostTempRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public StringField EmpId;
            public StringField CostId;
            public DateTimeField DDay;
            public StringField ShiftId;

            public Int32Field EmpKeyId;
            public StringField EmpFirstName;
            public StringField EmpLastName;
            public StringField EmpEmployeeName;
            public StringField EmpSexId;
            public DateTimeField EmpLeftDate;
            public DateTimeField EmpStartDate;
            public BooleanField EmpActive;

            public StringField StringName;

            public Int32Field ShiftKeyId;
            public StringField ShiftShiftName;
            public DateTimeField ShiftBeginTime;
            public DateTimeField ShiftEndTime;
            public BooleanField ShiftActive;
        }
    }
}
