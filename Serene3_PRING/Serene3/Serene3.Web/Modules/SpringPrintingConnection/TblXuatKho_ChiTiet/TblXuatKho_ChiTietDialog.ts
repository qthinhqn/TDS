/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.panel()
    @Serenity.Decorators.registerClass()
    export class TblXuatKho_ChiTietDialog extends Common.GridEditorDialog<TblXuatKho_ChiTietRow> {
    //export class TblXuatKho_ChiTietDialog extends Serenity.EntityDialog<TblXuatKho_ChiTietRow, any> {
        protected getFormKey() { return TblXuatKho_ChiTietForm.formKey; }
       // protected getIdProperty() { return TblXuatKho_ChiTietRow.idProperty; }
        protected getLocalTextPrefix() { return TblXuatKho_ChiTietRow.localTextPrefix; }
       // protected getService() { return TblXuatKho_ChiTietService.baseUrl; }

        protected form = new TblXuatKho_ChiTietForm(this.idPrefix);

    }
}