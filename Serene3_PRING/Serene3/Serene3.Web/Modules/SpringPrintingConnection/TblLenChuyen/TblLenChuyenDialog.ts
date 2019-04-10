
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class TblLenChuyenDialog extends Serenity.EntityDialog<TblLenChuyenRow, any> {
        protected getFormKey() { return TblLenChuyenForm.formKey; }
        protected getIdProperty() { return TblLenChuyenRow.idProperty; }
        protected getLocalTextPrefix() { return TblLenChuyenRow.localTextPrefix; }
        protected getService() { return TblLenChuyenService.baseUrl; }

        protected form = new TblLenChuyenForm(this.idPrefix);
        protected updateInterface(): void {
            super.updateInterface();
            if (!(Authorization.hasPermission("Serene3:TblLenChuyen:Modify"))) {
                this.deleteButton.hide();
                this.saveAndCloseButton.hide();
                this.applyChangesButton.hide();
                Serenity.EditorUtils.setReadonly(this.element.find('.editor'), true);
            }
            if (!(Authorization.hasPermission("Serene3:TblLenChuyen:Delete"))) {
                this.deleteButton.hide();
            }
        }
    }
}