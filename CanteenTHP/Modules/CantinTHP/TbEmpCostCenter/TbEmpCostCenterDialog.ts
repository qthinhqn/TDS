
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpCostCenterDialog extends _Ext.DialogBase<TbEmpCostCenterRow, any> {
        protected getFormKey() { return TbEmpCostCenterForm.formKey; }
        protected getIdProperty() { return TbEmpCostCenterRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpCostCenterRow.localTextPrefix; }
        protected getNameProperty() { return TbEmpCostCenterRow.nameProperty; }
        protected getService() { return TbEmpCostCenterService.baseUrl; }

        protected form = new TbEmpCostCenterForm(this.idPrefix);

    }
}