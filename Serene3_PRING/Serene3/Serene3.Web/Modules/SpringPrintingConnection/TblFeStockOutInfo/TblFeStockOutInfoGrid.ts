
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblFeStockOutInfoGrid extends Serenity.EntityGrid<TblFeStockOutInfoRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblFeStockOutInfo'; }
        protected getDialogType() { return TblFeStockOutInfoDialog; }
        protected getIdProperty() { return TblFeStockOutInfoRow.idProperty; }
        protected getLocalTextPrefix() { return TblFeStockOutInfoRow.localTextPrefix; }
        protected getService() { return TblFeStockOutInfoService.baseUrl; }

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