
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class VChiTietBtp_SizeGrid extends Serenity.EntityGrid<VChiTietBtp_SizeRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.VChiTietBtp_Size'; }
        protected getDialogType() { return VChiTietBtp_SizeDialog; }
        protected getIdProperty() { return VChiTietBtp_SizeRow.idProperty; }
        protected getLocalTextPrefix() { return VChiTietBtp_SizeRow.localTextPrefix; }
        protected getService() { return VChiTietBtp_SizeService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}