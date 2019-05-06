
namespace Canteen.Administration.Entities
{
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    [ConnectionKey("Default"), Module("Administration"), TableName("Roles")]
    [DisplayName("Roles"), InstanceName("Role")]
    [ReadPermission(PermissionKeys.Security)]
    [ModifyPermission(PermissionKeys.Security)]
    [LookupScript]
    public sealed class RoleRow : Row, IIdRow, INameRow
    {
        [DisplayName("Role Id"), Identity, ForeignKey("Roles", "RoleId"), LeftJoin("jRole")]
        public Int32? RoleId
        {
            get { return Fields.RoleId[this]; }
            set { Fields.RoleId[this] = value; }
        }

        [DisplayName("Role Name"), Size(100), NotNull, QuickSearch]
        public String RoleName
        {
            get { return Fields.RoleName[this]; }
            set { Fields.RoleName[this] = value; }
        }

        [DisplayName("Details"), MasterDetailRelation(foreignKey: "RoleId", IncludeColumns = "EmployeeName, SexId, StartDate, LeftDate, CompanyKey, DepKey, IsManager, CanteenId, CostCenter"), NotMapped]
        public List<RoleSelectionRow> DetailList
        {
            get { return Fields.DetailList[this]; }
            set { Fields.DetailList[this] = value; }
        }

        [DisplayName("CostCenter Details"), MasterDetailRelation(foreignKey: "RoleId", IncludeColumns = "CostCenter"), NotMapped]
        public List<RoleCostCenterRow> CostCenterList
        {
            get { return Fields.CostCenterList[this]; }
            set { Fields.CostCenterList[this] = value; }
        }


        IIdField IIdRow.IdField
        {
            get { return Fields.RoleId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.RoleName; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public RoleRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field RoleId;
            public StringField RoleName;

            public RowListField<RoleSelectionRow> DetailList;

            public RowListField<RoleCostCenterRow> CostCenterList;
        }
    }
}