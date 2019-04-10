
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class VChiTietBtpGrid extends Serenity.EntityGrid<VChiTietBtpRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.VChiTietBtp'; }
        protected getDialogType() { return VChiTietBtpDialog; }
        protected getIdProperty() { return VChiTietBtpRow.idProperty; }
        protected getLocalTextPrefix() { return VChiTietBtpRow.localTextPrefix; }
        protected getService() { return VChiTietBtpService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        getButtons() {
            var buttons = super.getButtons();

            buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);

            return buttons;
        }
    }
}