
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblRefMauGrid extends Serenity.EntityGrid<TblRefMauRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblRefMau'; }
        protected getDialogType() { return TblRefMauDialog; }
        protected getIdProperty() { return TblRefMauRow.idProperty; }
        protected getLocalTextPrefix() { return TblRefMauRow.localTextPrefix; }
        protected getService() { return TblRefMauService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}