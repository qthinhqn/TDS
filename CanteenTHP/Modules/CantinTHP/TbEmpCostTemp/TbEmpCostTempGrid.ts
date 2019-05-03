
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpCostTempGrid extends _Ext.GridBase<TbEmpCostTempRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbEmpCostTemp'; }
        protected getDialogType() { return TbEmpCostTempDialog; }
        protected getIdProperty() { return TbEmpCostTempRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpCostTempRow.localTextPrefix; }
        protected getService() { return TbEmpCostTempService.baseUrl; }

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
                service: TbEmpCostTempService.baseUrl + '/TemplateExcel',
                separator: true
            }));

            // add our import button
            btns.push({
                title: 'Import From Excel',
                icon: 'fa fa-upload',
                cssClass: 'export-xlsx-button',
                onClick: () => {
                    // open import dialog, let it handle rest
                    var dialog = new EmpCostTempDialog();
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