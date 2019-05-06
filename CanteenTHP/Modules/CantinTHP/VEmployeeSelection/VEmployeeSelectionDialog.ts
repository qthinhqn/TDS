
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class VEmployeeSelectionDialog extends _Ext.DialogBase<VEmployeeSelectionRow, any> {
        protected getFormKey() { return VEmployeeSelectionForm.formKey; }
        protected getIdProperty() { return VEmployeeSelectionRow.idProperty; }
        protected getLocalTextPrefix() { return VEmployeeSelectionRow.localTextPrefix; }
        protected getNameProperty() { return VEmployeeSelectionRow.nameProperty; }
        protected getService() { return VEmployeeSelectionService.baseUrl; }

        protected form = new VEmployeeSelectionForm(this.idPrefix);

    }
}