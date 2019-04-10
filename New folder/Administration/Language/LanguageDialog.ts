﻿/// <reference path="../../_Ext/_q/_q.ts" />
namespace COCOSIN_ERP.Administration {

    @Serenity.Decorators.registerClass()
    export class LanguageDialog extends _Ext.DialogBase<LanguageRow, any> {
        protected getFormKey() { return LanguageForm.formKey; }
        protected getIdProperty() { return LanguageRow.idProperty; }
        protected getLocalTextPrefix() { return LanguageRow.localTextPrefix; }
        protected getNameProperty() { return LanguageRow.nameProperty; }
        protected getService() { return LanguageService.baseUrl; }

        protected form = new LanguageForm(this.idPrefix);
    }
}