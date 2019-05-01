
namespace Canteen.CantinTHP.Entities
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("CantinTHP"), Module("CantinTHP"), TableName("[dbo].[tbMealCost]")]
    [DisplayName("Tb Meal Cost"), InstanceName("Tb Meal Cost")]
    [ReadPermission("Administration:General")]
    [ModifyPermission("Administration:General")]
    public sealed class TbMealCostRow : Row, IIdRow, INameRow
    {
        [DisplayName("Key Id"), Column("KeyID"), Identity]
        public Int32? KeyId
        {
            get { return Fields.KeyId[this]; }
            set { Fields.KeyId[this] = value; }
        }

        [DisplayName("Date Change")]
        public DateTime? DateChange
        {
            get { return Fields.DateChange[this]; }
            set { Fields.DateChange[this] = value; }
        }

        [DisplayName("Employee Cost")]
        public Double? EmployeeCost
        {
            get { return Fields.EmployeeCost[this]; }
            set { Fields.EmployeeCost[this] = value; }
        }

        [DisplayName("Manager Cost")]
        public Double? ManagerCost
        {
            get { return Fields.ManagerCost[this]; }
            set { Fields.ManagerCost[this] = value; }
        }

        [DisplayName("Remarks"), Size(255), QuickSearch]
        public String Remarks
        {
            get { return Fields.Remarks[this]; }
            set { Fields.Remarks[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.KeyId; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Remarks; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public TbMealCostRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public Int32Field KeyId;
            public DateTimeField DateChange;
            public DoubleField EmployeeCost;
            public DoubleField ManagerCost;
            public StringField Remarks;
        }
    }
}
