
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefRegistrationTypeDialog extends Serenity.EntityDialog<TbRefRegistrationTypeRow, any> {
        protected getFormKey() { return TbRefRegistrationTypeForm.formKey; }
        protected getIdProperty() { return TbRefRegistrationTypeRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefRegistrationTypeRow.localTextPrefix; }
        protected getNameProperty() { return TbRefRegistrationTypeRow.nameProperty; }
        protected getService() { return TbRefRegistrationTypeService.baseUrl; }

        protected form = new TbRefRegistrationTypeForm(this.idPrefix);

    }
}