
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblRefNguoiDaiDienDialog extends Serenity.EntityDialog<TblRefNguoiDaiDienRow, any> {
        protected getFormKey() { return TblRefNguoiDaiDienForm.formKey; }
        protected getIdProperty() { return TblRefNguoiDaiDienRow.idProperty; }
        protected getLocalTextPrefix() { return TblRefNguoiDaiDienRow.localTextPrefix; }
        protected getNameProperty() { return TblRefNguoiDaiDienRow.nameProperty; }
        protected getService() { return TblRefNguoiDaiDienService.baseUrl; }

        protected form = new TblRefNguoiDaiDienForm(this.idPrefix);

    }
}