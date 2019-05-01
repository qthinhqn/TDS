
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpManagerGrid extends Serenity.EntityGrid<TbEmpManagerRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbEmpManager'; }
        protected getDialogType() { return TbEmpManagerDialog; }
        protected getIdProperty() { return TbEmpManagerRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpManagerRow.localTextPrefix; }
        protected getService() { return TbEmpManagerService.baseUrl; }

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
                service: TbEmpManagerService.baseUrl + '/TemplateExcel',
                separator: true
            }));

            // add our import button
            btns.push({
                title: 'Import From Excel',
                icon: 'fa fa-upload',
                cssClass: 'export-xlsx-button',
                onClick: () => {
                    // open import dialog, let it handle rest
                    var dialog = new EmpManagerDialog();
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