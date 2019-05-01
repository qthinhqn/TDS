
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpDayOffGrid extends Serenity.EntityGrid<TbEmpDayOffRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbEmpDayOff'; }
        protected getDialogType() { return TbEmpDayOffDialog; }
        protected getIdProperty() { return TbEmpDayOffRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpDayOffRow.localTextPrefix; }
        protected getService() { return TbEmpDayOffService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected getButtons(): Serenity.ToolButton[] {
            let btns = super.getButtons();

            // add our export template button
            btns.push(Common.ExcelExportHelper.createToolButton({
                title: 'Template File',
                grid: this,
                onViewSubmit: () => this.onViewSubmit(),
                service: TbEmpDayOffService.baseUrl + '/TemplateExcel',
                separator: true
            }));

            // add our import button
            btns.push({
                title: 'Import From Excel',
                icon: 'fa fa-upload',
                cssClass: 'export-xlsx-button',
                onClick: () => {
                    // open import dialog, let it handle rest
                    var dialog = new EmpDayOffDialog();
                    dialog.element.on('dialogclose', () => {
                        this.refresh();
                        dialog = null;
                    });
                    dialog.dialogOpen();
                }
            });

            return btns;
        }

    }
}