
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblBanThanhPhamGrid extends Serenity.EntityGrid<TblBanThanhPhamRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblBanThanhPham'; }
        protected getDialogType() { return TblBanThanhPhamDialog; }
        protected getIdProperty() { return TblBanThanhPhamRow.idProperty; }
        protected getLocalTextPrefix() { return TblBanThanhPhamRow.localTextPrefix; }
        protected getService() { return TblBanThanhPhamService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}