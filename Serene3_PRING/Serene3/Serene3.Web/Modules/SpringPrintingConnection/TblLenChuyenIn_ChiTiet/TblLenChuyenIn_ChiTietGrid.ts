
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblLenChuyenIn_ChiTietGrid extends Serenity.EntityGrid<TblLenChuyenIn_ChiTietRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblLenChuyenIn_ChiTiet'; }
        protected getDialogType() { return TblLenChuyenIn_ChiTietDialog; }
        protected getIdProperty() { return TblLenChuyenIn_ChiTietRow.idProperty; }
        protected getLocalTextPrefix() { return TblLenChuyenIn_ChiTietRow.localTextPrefix; }
        protected getService() { return TblLenChuyenIn_ChiTietService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}