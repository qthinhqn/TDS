
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblNguoiDungDialog extends Serenity.EntityDialog<TblNguoiDungRow, any> {
        protected getFormKey() { return TblNguoiDungForm.formKey; }
        protected getIdProperty() { return TblNguoiDungRow.idProperty; }
        protected getLocalTextPrefix() { return TblNguoiDungRow.localTextPrefix; }
        protected getNameProperty() { return TblNguoiDungRow.nameProperty; }
        protected getService() { return TblNguoiDungService.baseUrl; }

        protected form = new TblNguoiDungForm(this.idPrefix);

    }
}