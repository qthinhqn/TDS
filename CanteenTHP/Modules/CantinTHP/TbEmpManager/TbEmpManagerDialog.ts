
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpManagerDialog extends Serenity.EntityDialog<TbEmpManagerRow, any> {
        protected getFormKey() { return TbEmpManagerForm.formKey; }
        protected getIdProperty() { return TbEmpManagerRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpManagerRow.localTextPrefix; }
        protected getNameProperty() { return TbEmpManagerRow.nameProperty; }
        protected getService() { return TbEmpManagerService.baseUrl; }

        protected form = new TbEmpManagerForm(this.idPrefix);

    }
}