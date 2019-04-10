
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblFeCardInfoGrid extends Serenity.EntityGrid<TblFeCardInfoRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblFeCardInfo'; }
        protected getDialogType() { return TblFeCardInfoDialog; }
        protected getIdProperty() { return TblFeCardInfoRow.idProperty; }
        protected getLocalTextPrefix() { return TblFeCardInfoRow.localTextPrefix; }
        protected getService() { return TblFeCardInfoService.baseUrl; }

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