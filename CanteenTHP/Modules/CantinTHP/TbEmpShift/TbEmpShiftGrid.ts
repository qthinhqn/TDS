
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpShiftGrid extends _Ext.GridBase<TbEmpShiftRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbEmpShift'; }
        protected getDialogType() { return TbEmpShiftDialog; }
        protected getIdProperty() { return TbEmpShiftRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpShiftRow.localTextPrefix; }
        protected getService() { return TbEmpShiftService.baseUrl; }

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
                service: TbEmpShiftService.baseUrl + '/TemplateExcel',
                separator: true
            }));

            // add our import button
            btns.push({
                title: 'Import From Excel',
                icon: 'fa fa-upload',
                cssClass: 'export-xlsx-button',
                onClick: () => {
                    // open import dialog, let it handle rest
                    var dialog = new EmpShiftDialog();
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