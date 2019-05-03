
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefLeaveTypeDialog extends _Ext.DialogBase<TbRefLeaveTypeRow, any> {
        protected getFormKey() { return TbRefLeaveTypeForm.formKey; }
        protected getIdProperty() { return TbRefLeaveTypeRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefLeaveTypeRow.localTextPrefix; }
        protected getNameProperty() { return TbRefLeaveTypeRow.nameProperty; }
        protected getService() { return TbRefLeaveTypeService.baseUrl; }

        protected form = new TbRefLeaveTypeForm(this.idPrefix);

    }
}