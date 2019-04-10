
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblXuongChuyenIn_ChiTietGrid extends Serenity.EntityGrid<TblXuongChuyenIn_ChiTietRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblXuongChuyenIn_ChiTiet'; }
        protected getDialogType() { return TblXuongChuyenIn_ChiTietDialog; }
        protected getIdProperty() { return TblXuongChuyenIn_ChiTietRow.idProperty; }
        protected getLocalTextPrefix() { return TblXuongChuyenIn_ChiTietRow.localTextPrefix; }
        protected getService() { return TblXuongChuyenIn_ChiTietService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}