
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblXuongChuyenGrid extends Serenity.EntityGrid<TblXuongChuyenRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblXuongChuyen'; }
        protected getDialogType() { return TblXuongChuyenDialog; }
        protected getIdProperty() { return TblXuongChuyenRow.idProperty; }
        protected getLocalTextPrefix() { return TblXuongChuyenRow.localTextPrefix; }
        protected getService() { return TblXuongChuyenService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Serene3.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: TblXuongChuyenService.baseUrl + '/ListExcel',
                separator: true
            }));

            if (!(Authorization.hasPermission("Serene3:TblXuongChuyen:Modify"))) {
                buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            }

            return buttons;
        }
    }
}