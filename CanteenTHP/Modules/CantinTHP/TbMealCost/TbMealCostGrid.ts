
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbMealCostGrid extends Serenity.EntityGrid<TbMealCostRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbMealCost'; }
        protected getDialogType() { return TbMealCostDialog; }
        protected getIdProperty() { return TbMealCostRow.idProperty; }
        protected getLocalTextPrefix() { return TbMealCostRow.localTextPrefix; }
        protected getService() { return TbMealCostService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}