
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefCompanyDialog extends Serenity.EntityDialog<TbRefCompanyRow, any> {
        protected getFormKey() { return TbRefCompanyForm.formKey; }
        protected getIdProperty() { return TbRefCompanyRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefCompanyRow.localTextPrefix; }
        protected getNameProperty() { return TbRefCompanyRow.nameProperty; }
        protected getService() { return TbRefCompanyService.baseUrl; }

        protected form = new TbRefCompanyForm(this.idPrefix);

    }
}