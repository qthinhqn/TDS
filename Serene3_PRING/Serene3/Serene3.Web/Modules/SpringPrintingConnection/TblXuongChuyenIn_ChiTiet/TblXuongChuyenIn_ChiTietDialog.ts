/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.panel()
    @Serenity.Decorators.registerClass()
    export class TblXuongChuyenIn_ChiTietDialog extends Common.GridEditorDialog<TblXuongChuyenIn_ChiTietRow> {
    //export class TblXuongChuyenIn_ChiTietDialog extends Serenity.EntityDialog<TblXuongChuyenIn_ChiTietRow, any> {
        protected getFormKey() { return TblXuongChuyenIn_ChiTietForm.formKey; }
      //  protected getIdProperty() { return TblXuongChuyenIn_ChiTietRow.idProperty; }
        protected getLocalTextPrefix() { return TblXuongChuyenIn_ChiTietRow.localTextPrefix; }
        //protected getService() { return TblXuongChuyenIn_ChiTietService.baseUrl; }

        protected form = new TblXuongChuyenIn_ChiTietForm(this.idPrefix);

    }
}