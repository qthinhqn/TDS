
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefDepartmentDialog extends Serenity.EntityDialog<TbRefDepartmentRow, any> {
        protected getFormKey() { return TbRefDepartmentForm.formKey; }
        protected getIdProperty() { return TbRefDepartmentRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefDepartmentRow.localTextPrefix; }
        protected getNameProperty() { return TbRefDepartmentRow.nameProperty; }
        protected getService() { return TbRefDepartmentService.baseUrl; }

        protected form = new TbRefDepartmentForm(this.idPrefix);

    }
}