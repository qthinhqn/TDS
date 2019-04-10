
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblKhachHangDialog extends Serenity.EntityDialog<TblKhachHangRow, any> {
        protected getFormKey() { return TblKhachHangForm.formKey; }
        protected getIdProperty() { return TblKhachHangRow.idProperty; }
        protected getLocalTextPrefix() { return TblKhachHangRow.localTextPrefix; }
        protected getNameProperty() { return TblKhachHangRow.nameProperty; }
        protected getService() { return TblKhachHangService.baseUrl; }

        protected form = new TblKhachHangForm(this.idPrefix);

    }
}