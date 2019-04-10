
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblBo_BTPGrid extends Serenity.EntityGrid<TblBo_BTPRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblBo_BTP'; }
        protected getDialogType() { return TblBo_BTPDialog; }
        protected getIdProperty() { return TblBo_BTPRow.idProperty; }
        protected getLocalTextPrefix() { return TblBo_BTPRow.localTextPrefix; }
        protected getService() { return TblBo_BTPService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}