
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblKhachHangGrid extends Serenity.EntityGrid<TblKhachHangRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblKhachHang'; }
        protected getDialogType() { return TblKhachHangDialog; }
        protected getIdProperty() { return TblKhachHangRow.idProperty; }
        protected getLocalTextPrefix() { return TblKhachHangRow.localTextPrefix; }
        protected getService() { return TblKhachHangService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}