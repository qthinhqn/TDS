
namespace Serene3.SpringPrintingConnection {
    @Serenity.Decorators.filterable()
    @Serenity.Decorators.registerClass()
    export class TblNguoiDungGrid extends Serenity.EntityGrid<TblNguoiDungRow, any> {
        protected getColumnsKey() { return 'SpringPrintingConnection.TblNguoiDung'; }
        protected getDialogType() { return TblNguoiDungDialog; }
        protected getIdProperty() { return TblNguoiDungRow.idProperty; }
        protected getLocalTextPrefix() { return TblNguoiDungRow.localTextPrefix; }
        protected getService() { return TblNguoiDungService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}