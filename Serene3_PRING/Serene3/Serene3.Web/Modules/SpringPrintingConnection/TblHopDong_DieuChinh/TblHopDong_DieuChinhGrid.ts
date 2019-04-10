
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblHopDong_DieuChinhGrid extends Serenity.EntityGrid<TblHopDong_DieuChinhRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblHopDong_DieuChinh'; }
        protected getDialogType() { return TblHopDong_DieuChinhDialog; }
        protected getIdProperty() { return TblHopDong_DieuChinhRow.idProperty; }
        protected getLocalTextPrefix() { return TblHopDong_DieuChinhRow.localTextPrefix; }
        protected getService() { return TblHopDong_DieuChinhService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}