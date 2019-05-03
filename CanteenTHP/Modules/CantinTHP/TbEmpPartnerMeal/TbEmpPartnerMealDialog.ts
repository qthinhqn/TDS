
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpPartnerMealDialog extends _Ext.DialogBase<TbEmpPartnerMealRow, any> {
        protected getFormKey() { return TbEmpPartnerMealForm.formKey; }
        protected getIdProperty() { return TbEmpPartnerMealRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpPartnerMealRow.localTextPrefix; }
        protected getNameProperty() { return TbEmpPartnerMealRow.nameProperty; }
        protected getService() { return TbEmpPartnerMealService.baseUrl; }

        protected form = new TbEmpPartnerMealForm(this.idPrefix);

    }
}