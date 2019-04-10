/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblHopDongChiTietEditor extends Common.GridEditorBase<TblHopDongChiTietRow> {
        protected getColumnsKey() { return "SpringPrintingConnection.TblHopDongChiTiet"; }
        protected getDialogType() { return TblHopDongChiTietDialog; }
        protected getLocalTextPrefix() { return TblHopDongChiTietRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
        //protected getAddButtonCaption() { return "Add";}

        validateEntity(row, id) {
            alert("aaaaaa");
            row.KeyId = Q.toId(row.KeyId);

            var sameProduct = Q.tryFirst(this.view.getItems(), x => x.MaHd = row.MaHd);
            if (sameProduct && this.id(sameProduct) !== id) {
                Q.alert('This Contract is already in order details!');
                return false;
            }

            return true;
        }
    }
}