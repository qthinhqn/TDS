/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblHopDongDieuChinhDialog extends Common.GridEditorDialog<TblHopDongDieuChinhRow> {
        protected getFormKey() { return TblHopDongDieuChinhForm.formKey; }
        protected getIdProperty() { return TblHopDongDieuChinhRow.idProperty; }
        protected getLocalTextPrefix() { return TblHopDongDieuChinhRow.localTextPrefix; }
        protected getService() { return TblHopDongDieuChinhService.baseUrl; }

        protected form = new TblHopDongDieuChinhForm(this.idPrefix);

    }
}