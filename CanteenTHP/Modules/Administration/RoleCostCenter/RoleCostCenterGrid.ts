
namespace Canteen.Administration {

    @Serenity.Decorators.registerClass()
    export class RoleCostCenterGrid extends _Ext.GridBase<RoleCostCenterRow, any> {
        protected getColumnsKey() { return 'Administration.RoleCostCenter'; }
        protected getDialogType() { return RoleCostCenterDialog; }
        protected getIdProperty() { return RoleCostCenterRow.idProperty; }
        protected getLocalTextPrefix() { return RoleCostCenterRow.localTextPrefix; }
        protected getService() { return RoleCostCenterService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}