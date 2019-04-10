
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class VLenChuyenChiTietGrid extends Serenity.EntityGrid<VLenChuyenChiTietRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.VLenChuyenChiTiet'; }
        protected getDialogType() { return VLenChuyenChiTietDialog; }
        protected getIdProperty() { return VLenChuyenChiTietRow.idProperty; }
        protected getLocalTextPrefix() { return VLenChuyenChiTietRow.localTextPrefix; }
        protected getService() { return VLenChuyenChiTietService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}