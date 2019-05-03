
namespace Canteen.CantinTHP.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CantinTHP"), Module("CantinTHP"), TableName("[dbo].[tbEmployee]")]
    [DisplayName("Tb Employee"), InstanceName("Tb Employee")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    //[LeftJoin("em", "TbEmp_Manager", "em.[EmpID] = t0.[EmployeeID]", RowType = typeof(TbEmpManagerRow), TitlePrefix = "")]
    //[LeftJoin("ec", "TbEmp_Canteen", "ec.[EmpID] = t0.[EmployeeID]", RowType = typeof(TbEmpCanteenRow), TitlePrefix = "")]
    //[LeftJoin("eco", "TbEmp_Company", "eco.[EmpID] = t0.[EmployeeID]", RowType = typeof(TbEmpCompanyRow), TitlePrefix = "")]
    //[LeftJoin("ecc", "TbEmp_Costcenter", "ecc.[EmpID] = t0.[EmployeeID]", RowType = typeof(TbEmpCostCenterRow), TitlePrefix = "")]
    [LeftJoin("ed", "v_EmployeeInfoCurrent", "ed.[EmployeeID] = t0.[EmployeeID]", RowType = typeof(VEmployeeInfoCurrentRow), TitlePrefix = "")]
    [LookupScript(typeof(Scripts.TbEmployeeLookup))]

    public sealed class TbEmployeeRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Employee Id"), Column("EmployeeID"), Size(25), PrimaryKey, QuickSearch]
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

        [DisplayName("Start Date")]
        public DateTime? StartDate
        {
            get { return Fields.StartDate[this]; }
            set { Fields.StartDate[this] = value; }
        }

        [DisplayName("Active")]
        public Boolean? Active
        {
            get { return Fields.Active[this]; }
            set { Fields.Active[this] = value; }
        }

        [DisplayName("Company Key"), Expression("ed.[CompanyName]")]
        public String CompanyKey
        {
            get { return Fields.CompanyKey[this]; }
            set { Fields.CompanyKey[this] = value; }
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

        [DisplayName("String Name"), QuickSearch]
        [Expression("CONCAT('[' , T0.[EmployeeId] , '] ' , T0.[EmployeeName])")]
        public String StringName
        {
            get { return Fields.StringName[this]; }
            set { Fields.StringName[this] = value; }
        }

        [DisplayName("Details"), MasterDetailRelation(foreignKey: "EmpID"), NotMapped]
        public List<TbEmpCanteenRow> DetailList
        {
            get { return Fields.DetailList[this]; }
            set { Fields.DetailList[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.EmployeeId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.StringName; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TbEmployeeRow()
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
            public DateTimeField StartDate;
            public BooleanField Active;

            public StringField CompanyKey;
            public StringField DepKey;
            public BooleanField IsManager;
            public StringField CanteenId;
            public StringField CostCenter;
            public StringField StringName;

            public RowListField<TbEmpCanteenRow> DetailList;
        }
    }
}
