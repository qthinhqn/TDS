
namespace Canteen.Administration {

    @Serenity.Decorators.registerEditor()
    export class RoleCostCenterEditor extends _Ext.GridEditorBase<RoleCostCenterRow> {
        protected getColumnsKey() { return "Administration.RoleCostCenter"; }
        protected getDialogType() { return RoleCostCenterDialog; }
        protected getLocalTextPrefix() { return RoleCostCenterRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }

        validateEntity(row, id) {
            //row.ProductID = Q.toId(row.ProductID);

            //var sameProduct = Q.tryFirst(this.view.getItems(), x => x.ProductID === row.ProductID);
            //if (sameProduct && this.id(sameProduct) !== id) {
            //    Q.alert('This product is already in order details!');
            //    return false;
            //}

            //row.ProductName = ProductRow.getLookup().itemById[row.ProductID].ProductName;
            //row.LineTotal = (row.Quantity || 0) * (row.UnitPrice || 0) - (row.Discount || 0);
            return true;
        }

        protected getButtons() {
            let buttons = super.getButtons();
            
            return buttons;
        }

    }
}