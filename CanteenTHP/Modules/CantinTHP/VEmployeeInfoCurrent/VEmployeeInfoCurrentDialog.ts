
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class VEmployeeInfoCurrentDialog extends Serenity.EntityDialog<VEmployeeInfoCurrentRow, any> {
        protected getFormKey() { return VEmployeeInfoCurrentForm.formKey; }
        protected getIdProperty() { return VEmployeeInfoCurrentRow.idProperty; }
        protected getLocalTextPrefix() { return VEmployeeInfoCurrentRow.localTextPrefix; }
        protected getNameProperty() { return VEmployeeInfoCurrentRow.nameProperty; }
        protected getService() { return VEmployeeInfoCurrentService.baseUrl; }

        protected form = new VEmployeeInfoCurrentForm(this.idPrefix);

    }
}