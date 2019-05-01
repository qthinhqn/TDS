
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbPrintTicketGrid extends Serenity.EntityGrid<TbPrintTicketRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbPrintTicket'; }
        protected getDialogType() { return TbPrintTicketDialog; }
        protected getIdProperty() { return TbPrintTicketRow.idProperty; }
        protected getLocalTextPrefix() { return TbPrintTicketRow.localTextPrefix; }
        protected getService() { return TbPrintTicketService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}