
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class TblXuatKhoKhDialog extends Serenity.EntityDialog<TblXuatKhoKhRow, any> {
        protected getFormKey() { return TblXuatKhoKhForm.formKey; }
        protected getIdProperty() { return TblXuatKhoKhRow.idProperty; }
        protected getLocalTextPrefix() { return TblXuatKhoKhRow.localTextPrefix; }
        protected getNameProperty() { return TblXuatKhoKhRow.nameProperty; }
        protected getService() { return TblXuatKhoKhService.baseUrl; }

        protected form = new TblXuatKhoKhForm(this.idPrefix);
        protected updateInterface(): void {
            super.updateInterface();
            if (!(Authorization.hasPermission("Serene3:TblXuatKhoKh:Modify"))) {
                this.deleteButton.hide();
                this.saveAndCloseButton.hide();
                this.applyChangesButton.hide();
                Serenity.EditorUtils.setReadonly(this.element.find('.editor'), true);
            }
            if (!(Authorization.hasPermission("Serene3:TblXuatKhoKh:Delete"))) {
                this.deleteButton.hide();
            }
        }
    }
}