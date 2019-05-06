
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class VEmployeeSelectionGrid extends _Ext.GridBase<VEmployeeSelectionRow, any> {
        protected getColumnsKey() { return 'CantinTHP.VEmployeeSelection'; }
        protected getDialogType() { return VEmployeeSelectionDialog; }
        protected getIdProperty() { return VEmployeeSelectionRow.idProperty; }
        protected getLocalTextPrefix() { return VEmployeeSelectionRow.localTextPrefix; }
        protected getService() { return VEmployeeSelectionService.baseUrl; }

        constructor(container: JQuery, options?) {
            super(container, options);
        }
    }
}