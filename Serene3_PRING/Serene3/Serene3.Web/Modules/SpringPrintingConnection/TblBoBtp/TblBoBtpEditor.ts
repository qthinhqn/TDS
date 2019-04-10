/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblBoBtpEditor extends Common.GridEditorBase<TblBoBtpRow> {
        protected getColumnsKey() { return "SpringPrintingConnection.TblBoBtp"; }
        protected getDialogType() { return TblBoBtpEditDialog; }
        protected getLocalTextPrefix() { return TblBoBtpRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }

        validateEntity(row, id) {
            //row.MaLo = Q.toId(row.MaLo);

            //var sameProduct = Q.tryFirst(this.view.getItems(), x => x.MaLo === row.MaLo);
            //if (sameProduct && this.id(sameProduct) !== id) {
            //    Q.alert('This product is already in order details!');
            //    return false;
            //}
            return true;
        }
    }
}