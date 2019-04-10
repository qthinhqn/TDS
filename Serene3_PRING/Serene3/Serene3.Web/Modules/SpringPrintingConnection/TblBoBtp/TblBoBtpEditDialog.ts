/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    //export class TblBoBtpDialog extends Serenity.EntityDialog<TblBoBtpRow, any> {
        export class TblBoBtpEditDialog extends Common.GridEditorDialog<TblBoBtpRow> {
        protected getFormKey() { return TblBoBtpForm.formKey; }
        protected getIdProperty() { return TblBoBtpRow.idProperty; }
        protected getLocalTextPrefix() { return TblBoBtpRow.localTextPrefix; }
        protected getService() { return TblBoBtpService.baseUrl; }

        protected form = new TblBoBtpForm(this.idPrefix);

    }
}