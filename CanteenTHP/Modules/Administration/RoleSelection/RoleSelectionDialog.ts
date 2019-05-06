
namespace Canteen.Administration {

    @Serenity.Decorators.registerClass()
    export class RoleSelectionDialog extends Serenity.EntityDialog<RoleSelectionRow, any> {
        protected getFormKey() { return RoleSelectionForm.formKey; }
        protected getIdProperty() { return RoleSelectionRow.idProperty; }
        protected getLocalTextPrefix() { return RoleSelectionRow.localTextPrefix; }
        protected getNameProperty() { return RoleSelectionRow.nameProperty; }
        protected getService() { return RoleSelectionService.baseUrl; }

        protected form = new RoleSelectionForm(this.idPrefix);

    }
}