
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    //export class TblXuongChuyenInChiTietDialog extends Serenity.EntityDialog<TblXuongChuyenInChiTietRow, any> {
      export class TblXuongChuyenInChiTietDialog extends Serenity.EntityDialog<TblXuongChuyenInChiTietRow, any> {
        protected getFormKey() { return TblXuongChuyenInChiTietForm.formKey; }
        protected getIdProperty() { return TblXuongChuyenInChiTietRow.idProperty; }
        protected getLocalTextPrefix() { return TblXuongChuyenInChiTietRow.localTextPrefix; }
        protected getService() { return TblXuongChuyenInChiTietService.baseUrl; }

        protected form = new TblXuongChuyenInChiTietForm(this.idPrefix);
        protected updateInterface(): void {
            super.updateInterface();
            if (!(Authorization.hasPermission("Serene3:TblXuongChuyenInChiTiet:Modify"))) {
                this.deleteButton.hide();
                this.saveAndCloseButton.hide();
                this.applyChangesButton.hide();
                Serenity.EditorUtils.setReadonly(this.element.find('.editor'), true);
            }
            if (!(Authorization.hasPermission("Serene3:TblXuongChuyenInChiTiet:Delete"))) {
                this.deleteButton.hide();
            }
        }
    }
}