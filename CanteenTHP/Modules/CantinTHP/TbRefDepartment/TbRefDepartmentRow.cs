
namespace Canteen.CantinTHP.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CantinTHP"), Module("CantinTHP"), TableName("[dbo].[tbRef_Department]")]
    [DisplayName("Tb Ref Department"), InstanceName("Tb Ref Department")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    [LookupScript]
    public sealed class TbRefDepartmentRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Dep Key"), Size(10), PrimaryKey, QuickSearch]
        public String DepKey
        {
            get { return Fields.DepKey[this]; }
            set { Fields.DepKey[this] = value; }
        }

        [DisplayName("Dep Name"), Size(100), NotNull]
        public String DepName
        {
            get { return Fields.DepName[this]; }
            set { Fields.DepName[this] = value; }
        }

        [DisplayName("Dep Parent"), Size(10), ForeignKey("[dbo].[tbRef_Department]", "DepKey"), LeftJoin("jDepParent"), TextualField("DepParentDepName")]
        public String DepParent
        {
            get { return Fields.DepParent[this]; }
            set { Fields.DepParent[this] = value; }
        }

        [DisplayName("Cost Center"), Size(20)]
        public String CostCenter
        {
            get { return Fields.CostCenter[this]; }
            set { Fields.CostCenter[this] = value; }
        }

        [DisplayName("Company Key"), Size(10)]
        public String CompanyKey
        {
            get { return Fields.CompanyKey[this]; }
            set { Fields.CompanyKey[this] = value; }
        }

        [DisplayName("Level")]
        public Int32? iLevel
        {
            get { return Fields.iLevel[this]; }
            set { Fields.iLevel[this] = value; }
        }

        [DisplayName("Active")]
        public Boolean? Active
        {
            get { return Fields.Active[this]; }
            set { Fields.Active[this] = value; }
        }

        [DisplayName("Dep Parent Key Id"), Expression("jDepParent.[KeyID]")]
        public Int32? DepParentKeyId
        {
            get { return Fields.DepParentKeyId[this]; }
            set { Fields.DepParentKeyId[this] = value; }
        }

        [DisplayName("Dep Parent Dep Name"), Expression("jDepParent.[DepName]")]
        public String DepParentDepName
        {
            get { return Fields.DepParentDepName[this]; }
            set { Fields.DepParentDepName[this] = value; }
        }

        [DisplayName("Dep Parent"), Expression("jDepParent.[DepParent]")]
        public String DepParent1
        {
            get { return Fields.DepParent1[this]; }
            set { Fields.DepParent1[this] = value; }
        }

        [DisplayName("Dep Parent Cost Center"), Expression("jDepParent.[CostCenter]")]
        public String DepParentCostCenter
        {
            get { return Fields.DepParentCostCenter[this]; }
            set { Fields.DepParentCostCenter[this] = value; }
        }

        [DisplayName("Dep Parent Active"), Expression("jDepParent.[Active]")]
        public Boolean? DepParentActive
        {
            get { return Fields.DepParentActive[this]; }
            set { Fields.DepParentActive[this] = value; }
        }


        [DisplayName("String Name"), QuickSearch]
        [Expression("CONCAT('[' , T0.[DepKey] , '] ' , T0.[DepName])")]
        public String StringName
        {
            get { return Fields.StringName[this]; }
            set { Fields.StringName[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.StringName; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TbRefDepartmentRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public StringField DepKey;
            public StringField DepName;
            public StringField DepParent;
            public StringField CostCenter;
            public StringField CompanyKey;
            public Int32Field iLevel;
            public BooleanField Active;

            public Int32Field DepParentKeyId;
            public StringField DepParentDepName;
            public StringField DepParent1;
            public StringField DepParentCostCenter;
            public BooleanField DepParentActive;

            public StringField StringName;
        }
    }
}
