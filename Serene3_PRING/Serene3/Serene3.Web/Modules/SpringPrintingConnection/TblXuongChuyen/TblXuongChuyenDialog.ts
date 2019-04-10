
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class TblXuongChuyenDialog extends Serenity.EntityDialog<TblXuongChuyenRow, any> {
        protected getFormKey() { return TblXuongChuyenForm.formKey; }
        protected getIdProperty() { return TblXuongChuyenRow.idProperty; }
        protected getLocalTextPrefix() { return TblXuongChuyenRow.localTextPrefix; }
        protected getService() { return TblXuongChuyenService.baseUrl; }

        protected form = new TblXuongChuyenForm(this.idPrefix);
        protected updateInterface(): void {
            super.updateInterface();
            if (!(Authorization.hasPermission("Serene3:TblXuongChuyen:Modify"))) {
                this.deleteButton.hide();
                this.saveAndCloseButton.hide();
                this.applyChangesButton.hide();
                Serenity.EditorUtils.setReadonly(this.element.find('.editor'), true);
            }
            if (!(Authorization.hasPermission("Serene3:TblXuongChuyen:Delete"))) {
                this.deleteButton.hide();
            }
        }
    }
}