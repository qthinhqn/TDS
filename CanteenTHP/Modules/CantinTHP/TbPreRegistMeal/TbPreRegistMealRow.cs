
namespace Canteen.CantinTHP.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CantinTHP"), Module("CantinTHP"), TableName("[dbo].[tbPre_RegistMeal]")]
    [DisplayName("Tb Pre Regist Meal"), InstanceName("Tb Pre Regist Meal")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript]
    public sealed class TbPreRegistMealRow : Row, IIdRow, INameRow
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

        [DisplayName("Canteen"), Column("CanteenID"), Size(10), ForeignKey("[dbo].[tbRef_Canteen]", "CanteenID"), LeftJoin("jCanteen"), TextualField("CanteenCanteenName")]
        public String CanteenId
        {
            get { return Fields.CanteenId[this]; }
            set { Fields.CanteenId[this] = value; }
        }

        [DisplayName("Menu"), Column("MenuID"), Size(10), ForeignKey("[dbo].[tbRef_Menu]", "MenuID"), LeftJoin("jMenu"), TextualField("MenuMenuName")]
        public String MenuId
        {
            get { return Fields.MenuId[this]; }
            set { Fields.MenuId[this] = value; }
        }

        [DisplayName("Reg Type"), Column("RegTypeID"), ForeignKey("[dbo].[tbRef_RegistrationType]", "KeyID"), LeftJoin("jRegType"), TextualField("RegTypeRegId")]
        public Int32? RegTypeId
        {
            get { return Fields.RegTypeId[this]; }
            set { Fields.RegTypeId[this] = value; }
        }

        [DisplayName("Is Printed")]
        public Boolean? IsPrinted
        {
            get { return Fields.IsPrinted[this]; }
            set { Fields.IsPrinted[this] = value; }
        }

        [DisplayName("Remarks"), Size(255)]
        public String Remarks
        {
            get { return Fields.Remarks[this]; }
            set { Fields.Remarks[this] = value; }
        }

        [DisplayName("Cost Center"), Size(20)]
        public String CostCenter
        {
            get { return Fields.CostCenter[this]; }
            set { Fields.CostCenter[this] = value; }
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

        [DisplayName("Menu Key Id"), Expression("jMenu.[KeyID]")]
        public Int32? MenuKeyId
        {
            get { return Fields.MenuKeyId[this]; }
            set { Fields.MenuKeyId[this] = value; }
        }

        [DisplayName("Menu Menu Name"), Expression("jMenu.[MenuName]")]
        public String MenuMenuName
        {
            get { return Fields.MenuMenuName[this]; }
            set { Fields.MenuMenuName[this] = value; }
        }

        [DisplayName("Menu M Image"), Expression("jMenu.[mImage]")]
        public String MenuMImage
        {
            get { return Fields.MenuMImage[this]; }
            set { Fields.MenuMImage[this] = value; }
        }

        [DisplayName("Menu Remarks"), Expression("jMenu.[Remarks]")]
        public String MenuRemarks
        {
            get { return Fields.MenuRemarks[this]; }
            set { Fields.MenuRemarks[this] = value; }
        }

        [DisplayName("Menu Active"), Expression("jMenu.[Active]")]
        public Boolean? MenuActive
        {
            get { return Fields.MenuActive[this]; }
            set { Fields.MenuActive[this] = value; }
        }

        [DisplayName("Reg Type Reg Id"), Expression("jRegType.[RegID]")]
        public String RegTypeRegId
        {
            get { return Fields.RegTypeRegId[this]; }
            set { Fields.RegTypeRegId[this] = value; }
        }

        [DisplayName("Reg Type Reg Name"), Expression("jRegType.[RegName]")]
        public String RegTypeRegName
        {
            get { return Fields.RegTypeRegName[this]; }
            set { Fields.RegTypeRegName[this] = value; }
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

        public TbPreRegistMealRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public StringField EmpId;
            public DateTimeField DDay;
            public StringField ShiftId;
            public StringField CanteenId;
            public StringField MenuId;
            public Int32Field RegTypeId;
            public BooleanField IsPrinted;
            public StringField Remarks;
            public StringField CostCenter;
            public DateTimeField CreatedDate;
            public StringField UserCreate;

            public Int32Field EmpKeyId;
            public StringField EmpFirstName;
            public StringField EmpLastName;
            public StringField EmpEmployeeName;
            public StringField EmpSexId;
            public DateTimeField EmpLeftDate;
            public DateTimeField EmpStartDate;
            public BooleanField EmpActive;

            public Int32Field ShiftKeyId;
            public StringField ShiftShiftName;
            public DateTimeField ShiftBeginTime;
            public DateTimeField ShiftEndTime;
            public BooleanField ShiftActive;

            public Int32Field CanteenKeyId;
            public StringField CanteenCanteenName;
            public StringField CanteenContactPerson;
            public StringField CanteenPhoneNum;
            public StringField CanteenRemarks;
            public BooleanField CanteenActive;

            public Int32Field MenuKeyId;
            public StringField MenuMenuName;
            public StringField MenuMImage;
            public StringField MenuRemarks;
            public BooleanField MenuActive;

            public StringField RegTypeRegId;
            public StringField RegTypeRegName;
        }
    }
}
