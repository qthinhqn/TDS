
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class VTrangThaiBoBtpDialog extends Serenity.EntityDialog<VTrangThaiBoBtpRow, any> {
        protected getFormKey() { return VTrangThaiBoBtpForm.formKey; }
        protected getIdProperty() { return VTrangThaiBoBtpRow.idProperty; }
        protected getLocalTextPrefix() { return VTrangThaiBoBtpRow.localTextPrefix; }
        protected getNameProperty() { return VTrangThaiBoBtpRow.nameProperty; }
        protected getService() { return VTrangThaiBoBtpService.baseUrl; }

        protected form = new VTrangThaiBoBtpForm(this.idPrefix);

    }
}