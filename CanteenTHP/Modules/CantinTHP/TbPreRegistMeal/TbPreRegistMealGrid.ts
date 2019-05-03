
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbPreRegistMealGrid extends _Ext.GridBase<TbPreRegistMealRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbPreRegistMeal'; }
        protected getDialogType() { return TbPreRegistMealDialog; }
        protected getIdProperty() { return TbPreRegistMealRow.idProperty; }
        protected getLocalTextPrefix() { return TbPreRegistMealRow.localTextPrefix; }
        protected getService() { return TbPreRegistMealService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}