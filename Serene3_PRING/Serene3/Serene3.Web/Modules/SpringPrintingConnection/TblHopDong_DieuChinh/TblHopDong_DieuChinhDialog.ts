/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    //export class TblHopDong_DieuChinhDialog extends Serenity.EntityDialog<TblHopDong_DieuChinhRow, any> {
        export class TblHopDong_DieuChinhDialog extends Common.GridEditorDialog<TblHopDong_DieuChinhRow> {
        protected getFormKey() { return TblHopDong_DieuChinhForm.formKey; }
      //  protected getIdProperty() { return TblHopDong_DieuChinhRow.idProperty; }
        protected getLocalTextPrefix() { return TblHopDong_DieuChinhRow.localTextPrefix; }
       // protected getService() { return TblHopDong_DieuChinhService.baseUrl; }

        protected form = new TblHopDong_DieuChinhForm(this.idPrefix);
       
    }
}