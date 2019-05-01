
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefRegistrationTypeGrid extends Serenity.EntityGrid<TbRefRegistrationTypeRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbRefRegistrationType'; }
        protected getDialogType() { return TbRefRegistrationTypeDialog; }
        protected getIdProperty() { return TbRefRegistrationTypeRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefRegistrationTypeRow.localTextPrefix; }
        protected getService() { return TbRefRegistrationTypeService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}