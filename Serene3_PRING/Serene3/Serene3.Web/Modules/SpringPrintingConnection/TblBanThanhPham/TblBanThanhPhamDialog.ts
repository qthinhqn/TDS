
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblBanThanhPhamDialog extends Serenity.EntityDialog<TblBanThanhPhamRow, any> {
        protected getFormKey() { return TblBanThanhPhamForm.formKey; }
        protected getIdProperty() { return TblBanThanhPhamRow.idProperty; }
        protected getLocalTextPrefix() { return TblBanThanhPhamRow.localTextPrefix; }
        protected getNameProperty() { return TblBanThanhPhamRow.nameProperty; }
        protected getService() { return TblBanThanhPhamService.baseUrl; }

        protected form = new TblBanThanhPhamForm(this.idPrefix);

    }
}