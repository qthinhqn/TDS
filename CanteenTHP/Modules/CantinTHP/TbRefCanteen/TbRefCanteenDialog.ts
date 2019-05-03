
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefCanteenDialog extends _Ext.DialogBase<TbRefCanteenRow, any> {
        protected getFormKey() { return TbRefCanteenForm.formKey; }
        protected getIdProperty() { return TbRefCanteenRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefCanteenRow.localTextPrefix; }
        protected getNameProperty() { return TbRefCanteenRow.nameProperty; }
        protected getService() { return TbRefCanteenService.baseUrl; }

        protected form = new TbRefCanteenForm(this.idPrefix);

    }
}