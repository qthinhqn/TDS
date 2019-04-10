
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblFeStockOutInfoDialog extends Serenity.EntityDialog<TblFeStockOutInfoRow, any> {
        protected getFormKey() { return TblFeStockOutInfoForm.formKey; }
        protected getIdProperty() { return TblFeStockOutInfoRow.idProperty; }
        protected getLocalTextPrefix() { return TblFeStockOutInfoRow.localTextPrefix; }
        protected getNameProperty() { return TblFeStockOutInfoRow.nameProperty; }
        protected getService() { return TblFeStockOutInfoService.baseUrl; }

        protected form = new TblFeStockOutInfoForm(this.idPrefix);
        protected updateInterface(): void {
            super.updateInterface();
            this.deleteButton.hide();
            this.saveAndCloseButton.hide();
            this.applyChangesButton.hide();
        }
    }
}