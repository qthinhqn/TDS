
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpCostCenterGrid extends Serenity.EntityGrid<TbEmpCostCenterRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbEmpCostCenter'; }
        protected getDialogType() { return TbEmpCostCenterDialog; }
        protected getIdProperty() { return TbEmpCostCenterRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpCostCenterRow.localTextPrefix; }
        protected getService() { return TbEmpCostCenterService.baseUrl; }

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
                service: TbEmpCostCenterService.baseUrl + '/TemplateExcel',
                separator: true
            }));

            // add our import button
            btns.push({
                title: 'Import From Excel',
                icon: 'fa fa-upload',
                cssClass: 'export-xlsx-button',
                onClick: () => {
                    // open import dialog, let it handle rest
                    var dialog = new EmpCostCenterDialog();
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