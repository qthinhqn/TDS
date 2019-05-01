
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpDepartmentGrid extends Serenity.EntityGrid<TbEmpDepartmentRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbEmpDepartment'; }
        protected getDialogType() { return TbEmpDepartmentDialog; }
        protected getIdProperty() { return TbEmpDepartmentRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpDepartmentRow.localTextPrefix; }
        protected getService() { return TbEmpDepartmentService.baseUrl; }

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
                service: TbEmpDepartmentService.baseUrl + '/TemplateExcel',
                separator: true
            }));

            // add our import button
            btns.push({
                title: 'Import From Excel',
                icon: 'fa fa-upload',
                cssClass: 'export-xlsx-button',
                onClick: () => {
                    // open import dialog, let it handle rest
                    var dialog = new EmpDepartmentDialog();
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