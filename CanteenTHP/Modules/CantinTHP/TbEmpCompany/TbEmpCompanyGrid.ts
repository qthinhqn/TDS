
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpCompanyGrid extends Serenity.EntityGrid<TbEmpCompanyRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbEmpCompany'; }
        protected getDialogType() { return TbEmpCompanyDialog; }
        protected getIdProperty() { return TbEmpCompanyRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpCompanyRow.localTextPrefix; }
        protected getService() { return TbEmpCompanyService.baseUrl; }

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
                service: TbEmpCompanyService.baseUrl + '/TemplateExcel',
                separator: true
            }));

            // add our import button
            btns.push({
                title: 'Import From Excel',
                icon: 'fa fa-upload',
                cssClass: 'export-xlsx-button',
                onClick: () => {
                    // open import dialog, let it handle rest
                    var dialog = new EmpCompanyDialog();
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