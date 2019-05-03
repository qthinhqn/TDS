
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpDepartmentDialog extends _Ext.DialogBase<TbEmpDepartmentRow, any> {
        protected getFormKey() { return TbEmpDepartmentForm.formKey; }
        protected getIdProperty() { return TbEmpDepartmentRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpDepartmentRow.localTextPrefix; }
        protected getNameProperty() { return TbEmpDepartmentRow.nameProperty; }
        protected getService() { return TbEmpDepartmentService.baseUrl; }

        protected form = new TbEmpDepartmentForm(this.idPrefix);

    }
}