
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblHopDong_ChiTietGrid extends Serenity.EntityGrid<TblHopDong_ChiTietRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblHopDong_ChiTiet'; }
        protected getDialogType() { return TblHopDong_ChiTietDialog; }
        protected getIdProperty() { return TblHopDong_ChiTietRow.idProperty; }
        protected getLocalTextPrefix() { return TblHopDong_ChiTietRow.localTextPrefix; }
        protected getService() { return TblHopDong_ChiTietService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}