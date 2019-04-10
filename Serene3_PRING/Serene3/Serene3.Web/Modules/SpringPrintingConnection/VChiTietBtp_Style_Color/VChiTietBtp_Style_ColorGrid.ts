
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class VChiTietBtp_Style_ColorGrid extends Serenity.EntityGrid<VChiTietBtp_Style_ColorRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.VChiTietBtp_Style_Color'; }
        protected getDialogType() { return VChiTietBtp_Style_ColorDialog; }
        protected getIdProperty() { return VChiTietBtp_Style_ColorRow.idProperty; }
        protected getLocalTextPrefix() { return VChiTietBtp_Style_ColorRow.localTextPrefix; }
        protected getService() { return VChiTietBtp_Style_ColorService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}