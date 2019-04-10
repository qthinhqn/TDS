
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class VHopDongTrangThaiDialog extends Serenity.EntityDialog<VHopDongTrangThaiRow, any> {
        protected getFormKey() { return VHopDongTrangThaiForm.formKey; }
        protected getIdProperty() { return VHopDongTrangThaiRow.idProperty; }
        protected getLocalTextPrefix() { return VHopDongTrangThaiRow.localTextPrefix; }
        protected getNameProperty() { return VHopDongTrangThaiRow.nameProperty; }
        protected getService() { return VHopDongTrangThaiService.baseUrl; }

        protected form = new VHopDongTrangThaiForm(this.idPrefix);
        protected updateInterface(): void {
            super.updateInterface();
            this.deleteButton.hide();
            this.saveAndCloseButton.hide();
            this.applyChangesButton.hide();
        }
    }
}