
namespace Canteen.CantinTHP {

    @Serenity.Decorators.registerClass()
    export class TbRefCompanyGrid extends Serenity.EntityGrid<TbRefCompanyRow, any> {
        protected getColumnsKey() { return 'CantinTHP.TbRefCompany'; }
        protected getDialogType() { return TbRefCompanyDialog; }
        protected getIdProperty() { return TbRefCompanyRow.idProperty; }
        protected getLocalTextPrefix() { return TbRefCompanyRow.localTextPrefix; }
        protected getService() { return TbRefCompanyService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}