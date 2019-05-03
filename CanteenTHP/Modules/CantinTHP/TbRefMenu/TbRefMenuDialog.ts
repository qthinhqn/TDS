
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefMenuDialog extends _Ext.DialogBase<TbRefMenuRow, any> {
        protected getFormKey() { return TbRefMenuForm.formKey; }
        protected getIdProperty() { return TbRefMenuRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefMenuRow.localTextPrefix; }
        protected getNameProperty() { return TbRefMenuRow.nameProperty; }
        protected getService() { return TbRefMenuService.baseUrl; }

        protected form = new TbRefMenuForm(this.idPrefix);

    }
}