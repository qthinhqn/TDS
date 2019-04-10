
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblRefNguoiDaiDienGrid extends Serenity.EntityGrid<TblRefNguoiDaiDienRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblRefNguoiDaiDien'; }
        protected getDialogType() { return TblRefNguoiDaiDienDialog; }
        protected getIdProperty() { return TblRefNguoiDaiDienRow.idProperty; }
        protected getLocalTextPrefix() { return TblRefNguoiDaiDienRow.localTextPrefix; }
        protected getService() { return TblRefNguoiDaiDienService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}