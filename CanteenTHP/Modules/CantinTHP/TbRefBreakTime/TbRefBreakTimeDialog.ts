
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefBreakTimeDialog extends _Ext.DialogBase<TbRefBreakTimeRow, any> {
        protected getFormKey() { return TbRefBreakTimeForm.formKey; }
        protected getIdProperty() { return TbRefBreakTimeRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefBreakTimeRow.localTextPrefix; }
        protected getNameProperty() { return TbRefBreakTimeRow.nameProperty; }
        protected getService() { return TbRefBreakTimeService.baseUrl; }

        protected form = new TbRefBreakTimeForm(this.idPrefix);

    }
}