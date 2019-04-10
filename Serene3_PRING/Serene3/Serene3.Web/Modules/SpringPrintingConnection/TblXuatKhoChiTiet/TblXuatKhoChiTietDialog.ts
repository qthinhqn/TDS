
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblXuatKhoChiTietDialog extends Serenity.EntityDialog<TblXuatKhoChiTietRow, any> {
        protected getFormKey() { return TblXuatKhoChiTietForm.formKey; }
        protected getIdProperty() { return TblXuatKhoChiTietRow.idProperty; }
        protected getLocalTextPrefix() { return TblXuatKhoChiTietRow.localTextPrefix; }
        protected getService() { return TblXuatKhoChiTietService.baseUrl; }

        protected form = new TblXuatKhoChiTietForm(this.idPrefix);
        protected updateInterface(): void {
            super.updateInterface();
            if (!(Authorization.hasPermission("Serene3:TblXuatKhoChiTiet:Modify"))) {
                this.deleteButton.hide();
                this.saveAndCloseButton.hide();
                this.applyChangesButton.hide();
                Serenity.EditorUtils.setReadonly(this.element.find('.editor'), true);
            }
            if (!(Authorization.hasPermission("Serene3:TblXuatKhoChiTiet:Delete"))) {
                this.deleteButton.hide();
            }
        }
    }
}