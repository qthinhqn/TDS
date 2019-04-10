
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblBoBtpDialog extends Serenity.EntityDialog<TblBoBtpRow, any> {
        protected getFormKey() { return TblBoBtpForm.formKey; }
        protected getIdProperty() { return TblBoBtpRow.idProperty; }
        protected getLocalTextPrefix() { return TblBoBtpRow.localTextPrefix; }
        protected getNameProperty() { return TblBoBtpRow.nameProperty; }
        protected getService() { return TblBoBtpService.baseUrl; }

        protected form = new TblBoBtpForm(this.idPrefix);
        protected updateInterface(): void {
            super.updateInterface();
            if (!(Authorization.hasPermission("Serene3:TblBoBtp:Modify"))) {
                this.deleteButton.hide();
                this.saveAndCloseButton.hide();
                this.applyChangesButton.hide();
                Serenity.EditorUtils.setReadonly(this.element.find('.editor'), true);
            }
            if (!(Authorization.hasPermission("Serene3:TblBoBtp:Delete"))) {
                this.deleteButton.hide();
            }
        }
    }
}