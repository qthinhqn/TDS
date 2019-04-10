
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class TblHopDongGrid extends Serenity.EntityGrid<TblHopDongRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblHopDong'; }
        protected getDialogType() { return TblHopDongDialog; }
        protected getIdProperty() { return TblHopDongRow.idProperty; }
        protected getLocalTextPrefix() { return TblHopDongRow.localTextPrefix; }
        protected getService() { return TblHopDongService.baseUrl; }

        constructor(container: JQuery) {
            super(container);

            ////Hide NoiDung column
            //let columns = this.getColumns();
            //columns = columns.filter(f => f.field != 'MaKhTenKh');
            //this.slickGrid.setColumns(columns);

        }

        getButtons() {
            var buttons = super.getButtons();

            buttons.push(Serene3.Common.ExcelExportHelper.createToolButton({
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: TblHopDongService.baseUrl + '/ListExcel',
                separator: true
            }));

            if (!(Authorization.hasPermission("Serene3:TblHopDong:Modify"))) {
                buttons.splice(Q.indexOf(buttons, x => x.cssClass == "add-button"), 1);
            }

            
            return buttons;
        }
    }
}