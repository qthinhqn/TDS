
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblLenChuyenInChiTietDialog extends Serenity.EntityDialog<TblLenChuyenInChiTietRow, any> {
        protected getFormKey() { return TblLenChuyenInChiTietForm.formKey; }
        protected getIdProperty() { return TblLenChuyenInChiTietRow.idProperty; }
        protected getLocalTextPrefix() { return TblLenChuyenInChiTietRow.localTextPrefix; }
        protected getService() { return TblLenChuyenInChiTietService.baseUrl; }

        protected form = new TblLenChuyenInChiTietForm(this.idPrefix);

    }
}