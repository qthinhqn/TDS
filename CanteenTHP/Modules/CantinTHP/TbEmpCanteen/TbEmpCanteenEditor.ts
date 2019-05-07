/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerEditor()
    export class TbEmpCanteenEditor extends Common.GridEditorBase<TbEmpCanteenRow> {
        protected getColumnsKey() { return "CantinTHP.TbEmpCanteen"; }
        protected getDialogType() { return TbEmpCanteenDialog; }
        protected getLocalTextPrefix() { return TbEmpCanteenRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }

        protected getAddButtonCaption() {
            return "Add";
        }

        validateEntity(row: TbEmpCanteenRow, id) {
            if (!super.validateEntity(row, id))
                return false;

            row.CanteenCanteenName = TbRefCanteenRow.getLookup().itemById[row.CanteenId].CanteenName;
            //alert(row.CanteenCanteenName);

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
    }
}