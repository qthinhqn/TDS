
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefEmpTypeDialog extends _Ext.DialogBase<TbRefEmpTypeRow, any> {
        protected getFormKey() { return TbRefEmpTypeForm.formKey; }
        protected getIdProperty() { return TbRefEmpTypeRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefEmpTypeRow.localTextPrefix; }
        protected getNameProperty() { return TbRefEmpTypeRow.nameProperty; }
        protected getService() { return TbRefEmpTypeService.baseUrl; }

        protected form = new TbRefEmpTypeForm(this.idPrefix);

    }
}