
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class VEmployeeInfoCurrentGrid extends Serenity.EntityGrid<VEmployeeInfoCurrentRow, any> {
        protected getColumnsKey() { return 'CantinTHP.VEmployeeInfoCurrent'; }
        protected getDialogType() { return VEmployeeInfoCurrentDialog; }
        protected getIdProperty() { return VEmployeeInfoCurrentRow.idProperty; }
        protected getLocalTextPrefix() { return VEmployeeInfoCurrentRow.localTextPrefix; }
        protected getService() { return VEmployeeInfoCurrentService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}