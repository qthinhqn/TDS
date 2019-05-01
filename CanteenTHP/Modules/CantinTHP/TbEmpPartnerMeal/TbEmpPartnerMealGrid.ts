
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpPartnerMealGrid extends Serenity.EntityGrid<TbEmpPartnerMealRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbEmpPartnerMeal'; }
        protected getDialogType() { return TbEmpPartnerMealDialog; }
        protected getIdProperty() { return TbEmpPartnerMealRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpPartnerMealRow.localTextPrefix; }
        protected getService() { return TbEmpPartnerMealService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}