
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefShiftDialog extends _Ext.DialogBase<TbRefShiftRow, any> {
        protected getFormKey() { return TbRefShiftForm.formKey; }
        protected getIdProperty() { return TbRefShiftRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefShiftRow.localTextPrefix; }
        protected getNameProperty() { return TbRefShiftRow.nameProperty; }
        protected getService() { return TbRefShiftService.baseUrl; }

        protected form = new TbRefShiftForm(this.idPrefix);

    }
}