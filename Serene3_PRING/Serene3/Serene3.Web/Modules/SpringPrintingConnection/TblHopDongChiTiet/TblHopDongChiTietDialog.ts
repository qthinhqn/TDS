namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblHopDongChiTietDialog extends Serenity.EntityDialog<TblHopDongChiTietRow, any> {
       // export class TblHopDongChiTietDialog extends Common.GridEditorDialog<TblHopDongChiTietRow> {
        protected getFormKey() { return TblHopDongChiTietForm.formKey; }
        protected getIdProperty() { return TblHopDongChiTietRow.idProperty; }
        protected getLocalTextPrefix() { return TblHopDongChiTietRow.localTextPrefix; }
        protected getService() { return TblHopDongChiTietService.baseUrl; }

       // protected form = new TblHopDongChiTietForm(this.idPrefix);
        protected form: TblHopDongChiTietForm;
        constructor() {
            super();
            this.form = new TblHopDongChiTietForm(this.idPrefix);
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