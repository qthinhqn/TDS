
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.filterable()
    export class TbEmployeeGrid extends Serenity.EntityGrid<TbEmployeeRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbEmployee'; }
        protected getDialogType() { return TbEmployeeDialog; }
        protected getIdProperty() { return TbEmployeeRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmployeeRow.localTextPrefix; }
        protected getService() { return TbEmployeeService.baseUrl; }

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
                service: TbEmployeeService.baseUrl + '/TemplateExcel',
                separator: true
            }));

            // add our import button
            btns.push({
                title: 'Import From Excel',
                icon: 'fa fa-upload',
                cssClass: 'export-xlsx-button',
                onClick: () => {
                    // open import dialog, let it handle rest
                    var dialog = new EmployeeDialog();
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