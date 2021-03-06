﻿
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefDepartmentGrid extends _Ext.GridBase<TbRefDepartmentRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbRefDepartment'; }
        protected getDialogType() { return TbRefDepartmentDialog; }
        protected getIdProperty() { return TbRefDepartmentRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefDepartmentRow.localTextPrefix; }
        protected getService() { return TbRefDepartmentService.baseUrl; }

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
                service: TbRefDepartmentService.baseUrl + '/TemplateExcel',
                separator: true
            }));

            // add our import button
            btns.push({
                title: 'Import From Excel',
                icon: 'fa fa-upload',
                cssClass: 'export-xlsx-button',
                onClick: () => {
                    // open import dialog, let it handle rest
                    var dialog = new RefDepartmentDialog();
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