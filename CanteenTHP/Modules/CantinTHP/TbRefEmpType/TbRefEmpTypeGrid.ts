
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefEmpTypeGrid extends _Ext.GridBase<TbRefEmpTypeRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbRefEmpType'; }
        protected getDialogType() { return TbRefEmpTypeDialog; }
        protected getIdProperty() { return TbRefEmpTypeRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefEmpTypeRow.localTextPrefix; }
        protected getService() { return TbRefEmpTypeService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}