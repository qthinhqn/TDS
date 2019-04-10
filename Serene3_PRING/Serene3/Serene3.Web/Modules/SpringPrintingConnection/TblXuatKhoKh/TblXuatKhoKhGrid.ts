
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblXuatKhoKhGrid extends Serenity.EntityGrid<TblXuatKhoKhRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblXuatKhoKh'; }
        protected getDialogType() { return TblXuatKhoKhDialog; }
        protected getIdProperty() { return TblXuatKhoKhRow.idProperty; }
        protected getLocalTextPrefix() { return TblXuatKhoKhRow.localTextPrefix; }
        protected getService() { return TblXuatKhoKhService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Serene3.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: TblXuatKhoKhService.baseUrl + '/ListExcel',
                separator: true
            }));

            if (!(Authorization.hasPermission("Serene3:TblXuatKhoKh:Modify"))) {
                buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            }

            return buttons;
        }
    }
}