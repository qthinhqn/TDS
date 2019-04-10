
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblHopDongDieuChinhGrid extends Serenity.EntityGrid<TblHopDongDieuChinhRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblHopDongDieuChinh'; }
        protected getDialogType() { return TblHopDongDieuChinhDialog; }
        protected getIdProperty() { return TblHopDongDieuChinhRow.idProperty; }
        protected getLocalTextPrefix() { return TblHopDongDieuChinhRow.localTextPrefix; }
        protected getService() { return TblHopDongDieuChinhService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}