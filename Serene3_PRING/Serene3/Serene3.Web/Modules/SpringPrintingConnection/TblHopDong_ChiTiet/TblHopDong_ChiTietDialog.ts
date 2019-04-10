/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />
namespace Serene3.SpringPrintingConnection {
    //@Serenity.Decorators.panel()
    @Serenity.Decorators.registerClass()
        export class TblHopDong_ChiTietDialog extends Common.GridEditorDialog<TblHopDong_ChiTietRow> {
        protected getFormKey() { return TblHopDong_ChiTietForm.formKey; }
       // protected getIdProperty() { return TblHopDong_ChiTietRow.idProperty; }
       // protected getLocalTextPrefix() { return TblHopDong_ChiTietRow.localTextPrefix; }
        protected getService() { return TblHopDong_ChiTietService.baseUrl; }

        //protected form = new TblHopDong_ChiTietForm(this.idPrefix);
        protected form: TblHopDong_ChiTietForm;

        constructor() {
            super();

            this.form = new TblHopDong_ChiTietForm(this.idPrefix);
            this.form.SoLuong.changeSelect2(e => {
                this.form.ThanhTien.value = this.form.SoLuong.value * this.form.DonGia.value;
                //alert("aaa");
            });
            this.form.DonGia.changeSelect2(e => {
                this.form.ThanhTien.value = this.form.SoLuong.value * this.form.DonGia.value;
                //alert("bbbb");
            });
        }
    }
}