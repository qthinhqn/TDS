
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpRegistMealGrid extends _Ext.GridBase<TbEmpRegistMealRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbEmpRegistMeal'; }
        protected getDialogType() { return TbEmpRegistMealDialog; }
        protected getIdProperty() { return TbEmpRegistMealRow.idProperty; }
        protected getLocalTextPrefix() { return TbEmpRegistMealRow.localTextPrefix; }
        protected getService() { return TbEmpRegistMealService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}