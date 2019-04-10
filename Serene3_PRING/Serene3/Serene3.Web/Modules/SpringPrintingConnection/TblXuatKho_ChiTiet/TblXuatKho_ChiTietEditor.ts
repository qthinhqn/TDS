/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblXuatKho_ChiTietEditor extends Common.GridEditorBase<TblXuatKho_ChiTietRow> {
        protected getColumnsKey() { return "SpringPrintingConnection.TblXuatKho_ChiTiet"; }
        protected getDialogType() { return TblXuatKho_ChiTietDialog; }
        protected getLocalTextPrefix() { return TblXuatKho_ChiTietRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }

        validateEntity(row, id) {
            //row.KeyId = Q.toId(row.KeyId);

            //var sameProduct = Q.tryFirst(this.view.getItems(), x => x.MaPhieuXuat === row.KeyId);
            //if (sameProduct && this.id(sameProduct) !== id) {
            //    Q.alert('This Contract is already in order details!');
            //    return false;
            //}
            row.CT_MaBTP = VChiTietBtpRow.getLookup().itemById[row.MaBo].MaBtp;
            row.CT_MaMau = VChiTietBtp_Style_ColorRow.getLookup().itemById[row.MaBo].MaMau;
            row.CT_MaStyle = VChiTietBtp_StyleRow.getLookup().itemById[row.MaBo].MaStyle;
            row.CT_MaSize = VChiTietBtp_SizeRow.getLookup().itemById[row.MaBo].MaSize;
            return true;
        }
    }
}