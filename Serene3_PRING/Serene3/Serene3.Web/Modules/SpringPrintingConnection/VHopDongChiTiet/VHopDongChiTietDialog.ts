
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class VHopDongChiTietDialog extends Serenity.EntityDialog<VHopDongChiTietRow, any> {
        protected getFormKey() { return VHopDongChiTietForm.formKey; }
        protected getIdProperty() { return VHopDongChiTietRow.idProperty; }
        protected getLocalTextPrefix() { return VHopDongChiTietRow.localTextPrefix; }
        protected getNameProperty() { return VHopDongChiTietRow.nameProperty; }
        protected getService() { return VHopDongChiTietService.baseUrl; }

        protected form = new VHopDongChiTietForm(this.idPrefix);

    }
}