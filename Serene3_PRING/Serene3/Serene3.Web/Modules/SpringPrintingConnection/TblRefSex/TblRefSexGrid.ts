
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblRefSexGrid extends Serenity.EntityGrid<TblRefSexRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblRefSex'; }
        protected getDialogType() { return TblRefSexDialog; }
        protected getIdProperty() { return TblRefSexRow.idProperty; }
        protected getLocalTextPrefix() { return TblRefSexRow.localTextPrefix; }
        protected getService() { return TblRefSexService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}