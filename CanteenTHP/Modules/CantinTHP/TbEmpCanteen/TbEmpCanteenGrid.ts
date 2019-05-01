﻿
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpCanteenGrid extends Serenity.EntityGrid<TbEmpCanteenRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbEmpCanteen'; }
        protected getDialogType() { return TbEmpCanteenDialog; }
        protected getIdProperty() { return TbEmpCanteenRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpCanteenRow.localTextPrefix; }
        protected getService() { return TbEmpCanteenService.baseUrl; }

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
                service: TbEmpCanteenService.baseUrl + '/TemplateExcel',
                separator: true
            }));

            // add our import button
            btns.push({
                title: 'Import From Excel',
                icon: 'fa fa-upload',
                cssClass: 'export-xlsx-button',
                onClick: () => {
                    // open import dialog, let it handle rest
                    var dialog = new EmpCanteenDialog();
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