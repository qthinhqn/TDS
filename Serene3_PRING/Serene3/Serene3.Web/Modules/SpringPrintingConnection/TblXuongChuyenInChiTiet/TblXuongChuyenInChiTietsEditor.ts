﻿/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblXuongChuyenInChiTietsEditor extends Common.GridEditorBase<TblXuongChuyenInChiTietRow> {
        protected getColumnsKey() { return "SpringPrintingConnection.TblXuongChuyenInChiTiet"; }
        protected getDialogType() { return TblXuongChuyenInChiTietDialog; }
        protected getLocalTextPrefix() { return TblXuongChuyenInChiTietRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }

        validateEntity(row, id) {
            row.KeyId = Q.toId(row.KeyId);

            var sameProduct = Q.tryFirst(this.view.getItems(), x => x.MaXuongChuyen === row.KeyId);
            if (sameProduct && this.id(sameProduct) !== id) {
                Q.alert('This Contract is already in order details!');
                return false;
            }

            return true;
        }
    }
}