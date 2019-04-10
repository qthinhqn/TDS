/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblLenChuyenInChiTietsEditor extends Common.GridEditorBase<TblLenChuyenInChiTietRow> {
        protected getColumnsKey() { return "SpringPrintingConnection.TblLenChuyenInChiTiet"; }
        protected getDialogType() { return TblLenChuyenInChiTietDialog; }
        protected getLocalTextPrefix() { return TblLenChuyenInChiTietRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }

        validateEntity(row, id) {
            row.KeyId = Q.toId(row.KeyId);

            var sameProduct = Q.tryFirst(this.view.getItems(), x => x.MaLenChuyen === row.KeyId);
            if (sameProduct && this.id(sameProduct) !== id) {
                Q.alert('This Contract is already in order details!');
                return false;
            }

            return true;
        }
    }
}