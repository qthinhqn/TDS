
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class VNhapKhoSpGrid extends Serenity.EntityGrid<VNhapKhoSpRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.VNhapKhoSp'; }
        protected getDialogType() { return VNhapKhoSpDialog; }
        protected getIdProperty() { return VNhapKhoSpRow.idProperty; }
        protected getLocalTextPrefix() { return VNhapKhoSpRow.localTextPrefix; }
        protected getService() { return VNhapKhoSpService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}