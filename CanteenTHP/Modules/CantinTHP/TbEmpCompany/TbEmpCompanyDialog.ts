
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpCompanyDialog extends Serenity.EntityDialog<TbEmpCompanyRow, any> {
        protected getFormKey() { return TbEmpCompanyForm.formKey; }
        protected getIdProperty() { return TbEmpCompanyRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpCompanyRow.localTextPrefix; }
        protected getNameProperty() { return TbEmpCompanyRow.nameProperty; }
        protected getService() { return TbEmpCompanyService.baseUrl; }

        protected form = new TbEmpCompanyForm(this.idPrefix);

    }
}