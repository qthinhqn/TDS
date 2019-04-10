/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblHopDongDieuChinhsEditor extends Common.GridEditorBase<TblHopDongDieuChinhRow> {
        protected getColumnsKey() { return "SpringPrintingConnection.TblHopDongDieuChinh"; }
        protected getDialogType() { return TblHopDongDieuChinhDialog; }
        protected getLocalTextPrefix() { return TblHopDongDieuChinhRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }

        validateEntity(row, id) {
            row.KeyId = Q.toId(row.KeyId);

            var sameProduct = Q.tryFirst(this.view.getItems(), x => x.MaHd === row.KeyId);
            if (sameProduct && this.id(sameProduct) !== id) {
                Q.alert('This Contract is already in order details!');
                return false;
            }

            return true;
        }
    }
}