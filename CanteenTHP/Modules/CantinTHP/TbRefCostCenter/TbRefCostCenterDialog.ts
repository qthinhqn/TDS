
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefCostCenterDialog extends _Ext.DialogBase<TbRefCostCenterRow, any> {
        protected getFormKey() { return TbRefCostCenterForm.formKey; }
        protected getIdProperty() { return TbRefCostCenterRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefCostCenterRow.localTextPrefix; }
        protected getNameProperty() { return TbRefCostCenterRow.nameProperty; }
        protected getService() { return TbRefCostCenterService.baseUrl; }

        protected form = new TbRefCostCenterForm(this.idPrefix);

    }
}