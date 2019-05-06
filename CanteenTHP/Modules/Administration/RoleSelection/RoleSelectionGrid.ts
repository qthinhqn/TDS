
namespace Canteen.Administration {

    @Serenity.Decorators.registerClass()
    export class RoleSelectionGrid extends Serenity.EntityGrid<RoleSelectionRow, any> {
        protected getColumnsKey() { return 'Administration.RoleSelection'; }
        protected getDialogType() { return RoleSelectionDialog; }
        protected getIdProperty() { return RoleSelectionRow.idProperty; }
        protected getLocalTextPrefix() { return RoleSelectionRow.localTextPrefix; }
        protected getService() { return RoleSelectionService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}