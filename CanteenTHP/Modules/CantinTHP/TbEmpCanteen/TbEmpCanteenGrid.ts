
namespace Canteen.CantinTHP {

    import fld = CantinTHP.TbEmpCanteenRow.Fields;

    @Serenity.Decorators.registerClass()
    export class TbEmpCanteenGrid extends _Ext.GridBase<TbEmpCanteenRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbEmpCanteen'; }
        protected getDialogType() { return TbEmpCanteenDialog; }
        protected getIdProperty() { return TbEmpCanteenRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpCanteenRow.localTextPrefix; }
        protected getService() { return TbEmpCanteenService.baseUrl; }

        private isEditedFlag = 'isEdited'

        constructor(container: JQuery, options?) {
            super(container, options);

            //this.slickContainer.on('change', '.edit:input', (e) => this.inputsChange(e));

            this.slickGrid.onCellChange.subscribe((e, args) => {
                let item = args.item as TbEmpCanteenRow;
                item[this.isEditedFlag] = true;
                this.view.updateItem(item[this.getIdProperty()], item);
            });

            this.slickGrid.onBeforeEditCell.subscribe((e, args) => {
                let item = args.item as TbEmpCanteenRow;
                let column = args.column as Slick.Column;

                if (column.field == fld.StringName)
                {
                    alert(column.field);
                }
            });
        }

        protected getSlickOptions() {
            let opt = super.getSlickOptions();
            opt.editable = true;
            opt.autoEdit = true;
            return opt;
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

            btns.push({
                title: 'Save',
                cssClass: 'apply-changes-button',
                onClick: e => {
                    (this.slickGrid as any).getEditController().commitCurrentEdit();

                    var items = this.view.getItems().filter(q => q[this.isEditedFlag] == true);
                    items.forEach(item => {
                        if (item['RowNum'])
                            delete item['RowNum'];
                        if (item[this.isEditedFlag])
                            delete item[this.isEditedFlag];

                        TbEmpCanteenService.Update({ EntityId: item.KeyId, Entity: item },
                            response => {
                                Q.notifySuccess("Success !");
                            }
                        );
                    })
                },
                separator: true
            });

            return btns;
        }

    }
}