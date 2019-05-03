
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefCostCenterGrid extends _Ext.GridBase<TbRefCostCenterRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbRefCostCenter'; }
        protected getDialogType() { return TbRefCostCenterDialog; }
        protected getIdProperty() { return TbRefCostCenterRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefCostCenterRow.localTextPrefix; }
        protected getService() { return TbRefCostCenterService.baseUrl; }

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
                service: TbRefCostCenterService.baseUrl + '/TemplateExcel',
                separator: true
            }));

            // add our import button
            btns.push({
                title: 'Import From Excel',
                icon: 'fa fa-upload',
                cssClass: 'export-xlsx-button',
                onClick: () => {
                    // open import dialog, let it handle rest
                    var dialog = new RefCostCenterDialog();
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