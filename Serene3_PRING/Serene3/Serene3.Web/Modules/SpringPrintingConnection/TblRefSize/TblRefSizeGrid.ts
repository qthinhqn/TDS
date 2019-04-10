
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblRefSizeGrid extends Serenity.EntityGrid<TblRefSizeRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblRefSize'; }
        protected getDialogType() { return TblRefSizeDialog; }
        protected getIdProperty() { return TblRefSizeRow.idProperty; }
        protected getLocalTextPrefix() { return TblRefSizeRow.localTextPrefix; }
        protected getService() { return TblRefSizeService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}