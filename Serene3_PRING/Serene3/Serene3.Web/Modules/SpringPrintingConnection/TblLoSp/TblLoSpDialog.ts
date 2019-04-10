
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class TblLoSpDialog extends Serenity.EntityDialog<TblLoSpRow, any> {
        protected getFormKey() { return TblLoSpForm.formKey; }
        protected getIdProperty() { return TblLoSpRow.idProperty; }
        protected getLocalTextPrefix() { return TblLoSpRow.localTextPrefix; }
        protected getNameProperty() { return TblLoSpRow.nameProperty; }
        protected getService() { return TblLoSpService.baseUrl; }

        protected form = new TblLoSpForm(this.idPrefix);
        protected updateInterface(): void {
            super.updateInterface();
            if (!(Authorization.hasPermission("Serene3:TblLoSp:Modify"))) {
                this.deleteButton.hide();
                this.saveAndCloseButton.hide();
                this.applyChangesButton.hide();
                Serenity.EditorUtils.setReadonly(this.element.find('.editor'), true);
            }
            if (!(Authorization.hasPermission("Serene3:TblLoSp:Delete"))) {
                this.deleteButton.hide();
            }
        }
    }
}