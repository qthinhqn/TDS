
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefReason4AdjustDialog extends _Ext.DialogBase<TbRefReason4AdjustRow, any> {
        protected getFormKey() { return TbRefReason4AdjustForm.formKey; }
        protected getIdProperty() { return TbRefReason4AdjustRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefReason4AdjustRow.localTextPrefix; }
        protected getNameProperty() { return TbRefReason4AdjustRow.nameProperty; }
        protected getService() { return TbRefReason4AdjustService.baseUrl; }

        protected form = new TbRefReason4AdjustForm(this.idPrefix);

    }
}