/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblXuatKhoChiTietsEditor extends Common.GridEditorBase<TblXuatKhoChiTietRow> {
        protected getColumnsKey() { return "SpringPrintingConnection.TblXuatKhoChiTiet"; }
        protected getDialogType() { return TblXuatKhoChiTietDialog; }
        protected getLocalTextPrefix() { return TblXuatKhoChiTietRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }

        validateEntity(row, id) {
            row.KeyId = Q.toId(row.KeyId);

            var sameProduct = Q.tryFirst(this.view.getItems(), x => x.MaPhieuXuat === row.KeyId);
            if (sameProduct && this.id(sameProduct) !== id) {
                Q.alert('This Contract is already in order details!');
                return false;
            }

            return true;
        }
    }
}