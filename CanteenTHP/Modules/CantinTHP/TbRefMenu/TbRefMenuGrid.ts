
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefMenuGrid extends _Ext.GridBase<TbRefMenuRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbRefMenu'; }
        protected getDialogType() { return TbRefMenuDialog; }
        protected getIdProperty() { return TbRefMenuRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefMenuRow.localTextPrefix; }
        protected getService() { return TbRefMenuService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}