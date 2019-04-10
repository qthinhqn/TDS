
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblLoSpGrid extends Serenity.EntityGrid<TblLoSpRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblLoSp'; }
        protected getDialogType() { return TblLoSpDialog; }
        protected getIdProperty() { return TblLoSpRow.idProperty; }
        protected getLocalTextPrefix() { return TblLoSpRow.localTextPrefix; }
        protected getService() { return TblLoSpService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Serene3.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: TblLoSpService.baseUrl + '/ListExcel',
                separator: true
            }));

            if (!(Authorization.hasPermission("Serene3:TblLoSp:Modify"))) {
                buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            }

            return buttons;
        }
    }
}