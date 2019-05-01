
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbPrePartnerMealDialog extends Serenity.EntityDialog<TbPrePartnerMealRow, any> {
        protected getFormKey() { return TbPrePartnerMealForm.formKey; }
        protected getIdProperty() { return TbPrePartnerMealRow.idProperty; }
        protected getLocalTextPrefix() { return TbPrePartnerMealRow.localTextPrefix; }
        protected getNameProperty() { return TbPrePartnerMealRow.nameProperty; }
        protected getService() { return TbPrePartnerMealService.baseUrl; }

        protected form = new TbPrePartnerMealForm(this.idPrefix);

    }
}