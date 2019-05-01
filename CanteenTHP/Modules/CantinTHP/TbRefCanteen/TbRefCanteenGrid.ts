
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefCanteenGrid extends Serenity.EntityGrid<TbRefCanteenRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbRefCanteen'; }
        protected getDialogType() { return TbRefCanteenDialog; }
        protected getIdProperty() { return TbRefCanteenRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefCanteenRow.localTextPrefix; }
        protected getService() { return TbRefCanteenService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}