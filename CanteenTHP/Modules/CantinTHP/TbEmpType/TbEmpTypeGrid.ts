
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpTypeGrid extends Serenity.EntityGrid<TbEmpTypeRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbEmpType'; }
        protected getDialogType() { return TbEmpTypeDialog; }
        protected getIdProperty() { return TbEmpTypeRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpTypeRow.localTextPrefix; }
        protected getService() { return TbEmpTypeService.baseUrl; }

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
                service: TbEmpTypeService.baseUrl + '/TemplateExcel',
                separator: true
            }));

            // add our import button
            btns.push({
                title: 'Import From Excel',
                icon: 'fa fa-upload',
                cssClass: 'export-xlsx-button',
                onClick: () => {
                    // open import dialog, let it handle rest
                    var dialog = new EmpTypeDialog();
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