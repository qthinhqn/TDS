
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefLeaveTypeGrid extends Serenity.EntityGrid<TbRefLeaveTypeRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbRefLeaveType'; }
        protected getDialogType() { return TbRefLeaveTypeDialog; }
        protected getIdProperty() { return TbRefLeaveTypeRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefLeaveTypeRow.localTextPrefix; }
        protected getService() { return TbRefLeaveTypeService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}