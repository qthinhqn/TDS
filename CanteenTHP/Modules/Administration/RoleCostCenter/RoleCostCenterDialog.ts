
namespace Canteen.Administration {

    @Serenity.Decorators.registerClass()
    export class RoleCostCenterDialog extends _Ext.DialogBase<RoleCostCenterRow, any> {
        protected getFormKey() { return RoleCostCenterForm.formKey; }
        protected getIdProperty() { return RoleCostCenterRow.idProperty; }
        protected getLocalTextPrefix() { return RoleCostCenterRow.localTextPrefix; }
        protected getNameProperty() { return RoleCostCenterRow.nameProperty; }
        protected getService() { return RoleCostCenterService.baseUrl; }

        protected form = new RoleCostCenterForm(this.idPrefix);

    }
}