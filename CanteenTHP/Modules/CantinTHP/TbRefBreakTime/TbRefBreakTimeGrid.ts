
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefBreakTimeGrid extends Serenity.EntityGrid<TbRefBreakTimeRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbRefBreakTime'; }
        protected getDialogType() { return TbRefBreakTimeDialog; }
        protected getIdProperty() { return TbRefBreakTimeRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefBreakTimeRow.localTextPrefix; }
        protected getService() { return TbRefBreakTimeService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}