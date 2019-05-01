
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbPreRegistMealDialog extends Serenity.EntityDialog<TbPreRegistMealRow, any> {
        protected getFormKey() { return TbPreRegistMealForm.formKey; }
        protected getIdProperty() { return TbPreRegistMealRow.idProperty; }
        protected getLocalTextPrefix() { return TbPreRegistMealRow.localTextPrefix; }
        protected getNameProperty() { return TbPreRegistMealRow.nameProperty; }
        protected getService() { return TbPreRegistMealService.baseUrl; }

        protected form = new TbPreRegistMealForm(this.idPrefix);

    }
}