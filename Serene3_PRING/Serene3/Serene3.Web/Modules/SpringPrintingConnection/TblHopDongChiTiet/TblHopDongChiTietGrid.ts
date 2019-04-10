
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblHopDongChiTietGrid extends Serenity.EntityGrid<TblHopDongChiTietRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblHopDongChiTiet'; }
        protected getDialogType() { return TblHopDongChiTietDialog; }
        protected getIdProperty() { return TblHopDongChiTietRow.idProperty; }
        protected getLocalTextPrefix() { return TblHopDongChiTietRow.localTextPrefix; }
        protected getService() { return TblHopDongChiTietService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}