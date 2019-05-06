
namespace Canteen.Administration.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), Module("Administration"), TableName("[dbo].[RoleCostCenter]")]
    [DisplayName("Role Cost Center"), InstanceName("Role Cost Center")]
    [ReadPermission(PermissionKeys.Security)]
    [ModifyPermission(PermissionKeys.Security)]
    public sealed class RoleCostCenterRow : Row, IIdRow, INameRow
    {
        [DisplayName("Role Cost Center Id"), Identity]
        public Int64? RoleCostCenterId
        {
            get { return Fields.RoleCostCenterId[this]; }
            set { Fields.RoleCostCenterId[this] = value; }
        }

        [DisplayName("Role"), NotNull, ForeignKey("[dbo].[Roles]", "RoleId"), LeftJoin("jRole"), TextualField("RoleRoleName")]
        public Int32? RoleId
        {
            get { return Fields.RoleId[this]; }
            set { Fields.RoleId[this] = value; }
        }

        [DisplayName("Cost Center"), Size(20), NotNull, ForeignKey("[dbo].[tbRef_CostCenter]", "CostCenter"), LeftJoin("jCostCenter"), QuickSearch]
        public String CostCenter
        {
            get { return Fields.CostCenter[this]; }
            set { Fields.CostCenter[this] = value; }
        }

        [DisplayName("Role Role Name"), Expression("jRole.[RoleName]")]
        public String RoleRoleName
        {
            get { return Fields.RoleRoleName[this]; }
            set { Fields.RoleRoleName[this] = value; }
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
            get { return Fields.RoleCostCenterId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.CostCenter; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public RoleCostCenterRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int64Field RoleCostCenterId;
            public Int32Field RoleId;
            public StringField CostCenter;

            public StringField RoleRoleName;

            public Int32Field CostCenterKeyId;
            public StringField CostCenterRemarks;
            public BooleanField CostCenterIsTemp;
            public DateTimeField CostCenterCreatedDate;
            public StringField CostCenterUserCreate;
            public BooleanField CostCenterActive;
        }
    }
}
