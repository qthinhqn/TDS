
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbPrePartnerMealGrid extends _Ext.GridBase<TbPrePartnerMealRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbPrePartnerMeal'; }
        protected getDialogType() { return TbPrePartnerMealDialog; }
        protected getIdProperty() { return TbPrePartnerMealRow.idProperty; }
        protected getLocalTextPrefix() { return TbPrePartnerMealRow.localTextPrefix; }
        protected getService() { return TbPrePartnerMealService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}