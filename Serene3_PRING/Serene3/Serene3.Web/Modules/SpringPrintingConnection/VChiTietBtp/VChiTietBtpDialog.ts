
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class VChiTietBtpDialog extends Serenity.EntityDialog<VChiTietBtpRow, any> {
        protected getFormKey() { return VChiTietBtpForm.formKey; }
        protected getIdProperty() { return VChiTietBtpRow.idProperty; }
        protected getLocalTextPrefix() { return VChiTietBtpRow.localTextPrefix; }
        protected getNameProperty() { return VChiTietBtpRow.nameProperty; }
        protected getService() { return VChiTietBtpService.baseUrl; }

        protected form = new VChiTietBtpForm(this.idPrefix);
        protected updateInterface(): void {
            super.updateInterface();
            this.deleteButton.hide();
            this.saveAndCloseButton.hide();
            this.applyChangesButton.hide();
        }
    }
}