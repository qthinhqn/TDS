
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefShiftGrid extends Serenity.EntityGrid<TbRefShiftRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbRefShift'; }
        protected getDialogType() { return TbRefShiftDialog; }
        protected getIdProperty() { return TbRefShiftRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefShiftRow.localTextPrefix; }
        protected getService() { return TbRefShiftService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}