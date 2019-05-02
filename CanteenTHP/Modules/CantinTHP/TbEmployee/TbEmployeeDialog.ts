
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.panel()
    export class TbEmployeeDialog extends _Ext.DialogBase<TbEmployeeRow, any> {
        protected getFormKey() { return TbEmployeeForm.formKey; }
        protected getIdProperty() { return TbEmployeeRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmployeeRow.localTextPrefix; }
        protected getNameProperty() { return TbEmployeeRow.nameProperty; }
        protected getService() { return TbEmployeeService.baseUrl; }

        protected form = new TbEmployeeForm(this.idPrefix);

    }
}