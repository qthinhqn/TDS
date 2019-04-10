
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblFeCardInfoDialog extends Serenity.EntityDialog<TblFeCardInfoRow, any> {
        protected getFormKey() { return TblFeCardInfoForm.formKey; }
        protected getIdProperty() { return TblFeCardInfoRow.idProperty; }
        protected getLocalTextPrefix() { return TblFeCardInfoRow.localTextPrefix; }
        protected getNameProperty() { return TblFeCardInfoRow.nameProperty; }
        protected getService() { return TblFeCardInfoService.baseUrl; }

        protected form = new TblFeCardInfoForm(this.idPrefix);
        protected updateInterface(): void {
            super.updateInterface();
            this.deleteButton.hide();
            this.saveAndCloseButton.hide();
            this.applyChangesButton.hide();
        }
    }
}