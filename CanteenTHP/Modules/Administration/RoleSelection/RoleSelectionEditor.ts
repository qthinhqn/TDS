
namespace Canteen.Administration {

    @Serenity.Decorators.registerEditor()
    export class RoleSelectionEditor extends _Ext.GridEditorBase<RoleSelectionRow> {
        protected getColumnsKey() { return "Administration.RoleSelection"; }
        protected getDialogType() { return RoleSelectionDialog; }
        protected getLocalTextPrefix() { return RoleSelectionRow.localTextPrefix; }

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
                        gridType: CantinTHP.VEmployeeSelectionGrid, multiple: true,
                        preSelectedKeys: this.value.map(k => k.EmpId)
                    });

                    pickerDialog.onSuccess = (selectedItems: any[]) => {
                        let selectedItems2 = selectedItems.filter(t => { return !Q.any(this.view.getItems(), n => n.EmpId == t.EmployeeId) });

                        var orderDetails = selectedItems2.map<CantinTHP.VEmployeeSelectionRow>(r => {
                            return {
                                EmpId: r.EmployeeId,
                                EmployeeName: r.EmployeeName,
                                SexId: r.SexId,
                                StartDate: r.StartDate,
                                LeftDate: r.LeftDate,
                                CompanyKey: r.CompanyName,
                                DepKey: r.DepName,
                                IsManager: r.IsManager,
                                CanteenId: r.CanteenName,
                                CostCenter: r.CostCenter
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