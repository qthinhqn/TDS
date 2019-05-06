/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Canteen.Administration {

    @Serenity.Decorators.registerEditor()
    export class RoleEditor extends Common.GridEditorBase<RoleRow> {
        protected getColumnsKey() { return "Administration.Role"; }
        protected getDialogType() { return RoleDialog; }
        protected getLocalTextPrefix() { return RoleRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }

        validateEntity(row, id) {
            //row.ProductID = Q.toId(row.ProductID);

            //var sameProduct = Q.tryFirst(this.view.getItems(), x => x.ProductID === row.ProductID);
            //if (sameProduct && this.id(sameProduct) !== id) {
            //    Q.alert('This product is already in order details!');
            //    return false;
            //}

            //row.ProductName = ProductRow.getLookup().itemById[row.ProductID].ProductName;
            //row.LineTotal = (row.Quantity || 0) * (row.UnitPrice || 0) - (row.Discount || 0);
            return true;
        }

        protected getButtons() {
            let buttons = super.getButtons();

            buttons.push({
                title: "Pick Employee",
                cssClass: "add-button",
                onClick: () => {
                    var pickerDialog = new _Ext.GridItemPickerDialog({
                        gridType: CantinTHP.VEmployeeInfoCurrentGrid, multiple: true,
                        preSelectedKeys: this.value.map(k => k.RoleId)
                    });

                    pickerDialog.onSuccess = (selectedItems: any[]) => {
                        let selectedItems2 = selectedItems.filter(t => { return !Q.any(this.view.getItems(), n => n.RoleId == t.RoleId) });

                        var orderDetails = selectedItems2.map<CantinTHP.VEmployeeInfoCurrentRow>(r => {
                            return {
                                RoleId: r.RoleId,
                                EmpId: r.EmployeeId
                            }
                        });

                        for (let orderDetail of orderDetails) {
                            orderDetail[this.getIdProperty()] = "`" + this.nextId++;
                            this.view.addItem(orderDetail);
                        }

                    }

                    pickerDialog.dialogOpen();
                }
            });

            return buttons;
        }

    }
}