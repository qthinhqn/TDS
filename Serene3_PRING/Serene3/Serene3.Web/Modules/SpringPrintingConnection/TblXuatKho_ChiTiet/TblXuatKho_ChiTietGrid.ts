
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblXuatKho_ChiTietGrid extends Serenity.EntityGrid<TblXuatKho_ChiTietRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblXuatKho_ChiTiet'; }
        protected getDialogType() { return TblXuatKho_ChiTietDialog; }
        protected getIdProperty() { return TblXuatKho_ChiTietRow.idProperty; }
        protected getLocalTextPrefix() { return TblXuatKho_ChiTietRow.localTextPrefix; }
        protected getService() { return TblXuatKho_ChiTietService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}