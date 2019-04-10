/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.panel()
    @Serenity.Decorators.registerClass()
    export class TblLenChuyenIn_ChiTietDialog extends Common.GridEditorDialog<TblLenChuyenIn_ChiTietRow> {
   // export class TblLenChuyenIn_ChiTietDialog extends Serenity.EntityDialog<TblLenChuyenIn_ChiTietRow, any> {
        protected getFormKey() { return TblLenChuyenIn_ChiTietForm.formKey; }
       // protected getIdProperty() { return TblLenChuyenIn_ChiTietRow.idProperty; }
        protected getLocalTextPrefix() { return TblLenChuyenIn_ChiTietRow.localTextPrefix; }
      //  protected getService() { return TblLenChuyenIn_ChiTietService.baseUrl; }

        protected form = new TblLenChuyenIn_ChiTietForm(this.idPrefix);
        //protected form: TblLenChuyenIn_ChiTietForm;

        //constructor() {
        //    super();

        //    this.form = new TblLenChuyenIn_ChiTietForm(this.idPrefix);
        //    this.form.SoLuong.changeSelect2(e => {
        //        this.form.ThanhTien.value = this.form.SoLuong.value * this.form.DonGia.value;
        //        //alert("aaa");
        //    });
        //    this.form.DonGia.changeSelect2(e => {
        //        this.form.ThanhTien.value = this.form.SoLuong.value * this.form.DonGia.value;
        //        //alert("bbbb");
        //    });


        //}
    }
}