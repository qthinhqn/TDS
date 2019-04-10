
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class VChiTietBtp_StyleDialog extends Serenity.EntityDialog<VChiTietBtp_StyleRow, any> {
        protected getFormKey() { return VChiTietBtp_StyleForm.formKey; }
        protected getIdProperty() { return VChiTietBtp_StyleRow.idProperty; }
        protected getLocalTextPrefix() { return VChiTietBtp_StyleRow.localTextPrefix; }
        protected getNameProperty() { return VChiTietBtp_StyleRow.nameProperty; }
        protected getService() { return VChiTietBtp_StyleService.baseUrl; }

        protected form = new VChiTietBtp_StyleForm(this.idPrefix);

    }
}