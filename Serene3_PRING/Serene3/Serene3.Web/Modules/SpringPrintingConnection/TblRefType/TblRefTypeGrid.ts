
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblRefTypeGrid extends Serenity.EntityGrid<TblRefTypeRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblRefType'; }
        protected getDialogType() { return TblRefTypeDialog; }
        protected getIdProperty() { return TblRefTypeRow.idProperty; }
        protected getLocalTextPrefix() { return TblRefTypeRow.localTextPrefix; }
        protected getService() { return TblRefTypeService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}