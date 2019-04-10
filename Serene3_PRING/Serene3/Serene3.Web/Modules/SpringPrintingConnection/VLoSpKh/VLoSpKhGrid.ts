
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class VLoSpKhGrid extends Serenity.EntityGrid<VLoSpKhRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.VLoSpKh'; }
        protected getDialogType() { return VLoSpKhDialog; }
        protected getIdProperty() { return VLoSpKhRow.idProperty; }
        protected getLocalTextPrefix() { return VLoSpKhRow.localTextPrefix; }
        protected getService() { return VLoSpKhService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}