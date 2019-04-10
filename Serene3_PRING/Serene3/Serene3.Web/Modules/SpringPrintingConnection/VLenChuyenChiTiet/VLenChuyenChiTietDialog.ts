
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class VLenChuyenChiTietDialog extends Serenity.EntityDialog<VLenChuyenChiTietRow, any> {
        protected getFormKey() { return VLenChuyenChiTietForm.formKey; }
        protected getIdProperty() { return VLenChuyenChiTietRow.idProperty; }
        protected getLocalTextPrefix() { return VLenChuyenChiTietRow.localTextPrefix; }
        protected getNameProperty() { return VLenChuyenChiTietRow.nameProperty; }
        protected getService() { return VLenChuyenChiTietService.baseUrl; }

        protected form = new VLenChuyenChiTietForm(this.idPrefix);

    }
}