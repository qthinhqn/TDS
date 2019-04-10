
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblLenChuyenGrid extends Serenity.EntityGrid<TblLenChuyenRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblLenChuyen'; }
        protected getDialogType() { return TblLenChuyenDialog; }
        protected getIdProperty() { return TblLenChuyenRow.idProperty; }
        protected getLocalTextPrefix() { return TblLenChuyenRow.localTextPrefix; }
        protected getService() { return TblLenChuyenService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Serene3.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: TblLenChuyenService.baseUrl + '/ListExcel',
                separator: true
            }));

            if (!(Authorization.hasPermission("Serene3:TblLenChuyen:Modify"))) {
                buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            }

            return buttons;
        }
    }
}