/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    //export class TblBo_BTPDialog extends Serenity.EntityDialog<TblBo_BTPRow, any> {
    export class TblBo_BTPDialog extends Common.GridEditorDialog<TblBo_BTPRow> {
        protected getFormKey() { return TblBo_BTPForm.formKey; }
       // protected getIdProperty() { return TblBo_BTPRow.idProperty; }
        protected getLocalTextPrefix() { return TblBo_BTPRow.localTextPrefix; }
        protected getNameProperty() { return TblBo_BTPRow.nameProperty; }
       // protected getService() { return TblBo_BTPService.baseUrl; }

        protected form = new TblBo_BTPForm(this.idPrefix);

    }
}