
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class TblHopDongDialog extends Serenity.EntityDialog<TblHopDongRow, any> {
        protected getFormKey() { return TblHopDongForm.formKey; }
        protected getIdProperty() { return TblHopDongRow.idProperty; }
        protected getLocalTextPrefix() { return TblHopDongRow.localTextPrefix; }
        protected getNameProperty() { return TblHopDongRow.nameProperty; }
        protected getService() { return TblHopDongService.baseUrl; }

        protected form = new TblHopDongForm(this.idPrefix);

        protected updateInterface(): void {
            super.updateInterface();
            if (!(Authorization.hasPermission("Serene3:TblHopDong:Modify"))) {
                this.deleteButton.hide();
                this.saveAndCloseButton.hide();
                this.applyChangesButton.hide();
                Serenity.EditorUtils.setReadonly(this.element.find('.editor'), true);
            }
            if (!(Authorization.hasPermission("Serene3:TblHopDong:Delete"))) {
                this.deleteButton.hide();
            }
        }
    }
}