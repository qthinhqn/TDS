/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />

namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbEmpCanteenDialog extends _Ext.DialogBase<TbEmpCanteenRow, any> {
        protected getFormKey() { return TbEmpCanteenForm.formKey; }
        protected getNameProperty() { return TbEmpCanteenRow.nameProperty; }
        protected getLocalTextPrefix() { return TbEmpCanteenRow.localTextPrefix; }

        protected form : TbEmpCanteenForm;

        constructor() {
            super();
            this.form = new TbEmpCanteenForm(this.idPrefix);
        }
    }
}