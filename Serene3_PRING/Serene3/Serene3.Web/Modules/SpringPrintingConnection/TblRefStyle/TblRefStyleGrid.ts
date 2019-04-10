
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblRefStyleGrid extends Serenity.EntityGrid<TblRefStyleRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblRefStyle'; }
        protected getDialogType() { return TblRefStyleDialog; }
        protected getIdProperty() { return TblRefStyleRow.idProperty; }
        protected getLocalTextPrefix() { return TblRefStyleRow.localTextPrefix; }
        protected getService() { return TblRefStyleService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}