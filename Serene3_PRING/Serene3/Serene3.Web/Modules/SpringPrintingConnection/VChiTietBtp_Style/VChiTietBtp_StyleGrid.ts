
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class VChiTietBtp_StyleGrid extends Serenity.EntityGrid<VChiTietBtp_StyleRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.VChiTietBtp_Style'; }
        protected getDialogType() { return VChiTietBtp_StyleDialog; }
        protected getIdProperty() { return VChiTietBtp_StyleRow.idProperty; }
        protected getLocalTextPrefix() { return VChiTietBtp_StyleRow.localTextPrefix; }
        protected getService() { return VChiTietBtp_StyleService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}