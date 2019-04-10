/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblXuongChuyenIn_ChiTietEditor extends Common.GridEditorBase<TblXuongChuyenIn_ChiTietRow> {
        protected getColumnsKey() { return "SpringPrintingConnection.TblXuongChuyenIn_ChiTiet"; }
        protected getDialogType() { return TblXuongChuyenIn_ChiTietDialog; }
        protected getLocalTextPrefix() { return TblXuongChuyenIn_ChiTietRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }

        validateEntity(row, id) {
            row.KeyId = Q.toId(row.KeyId);
            //alert(VChiTietBtp_StyleRow.getLookup().itemById[row.MaBo].MaStyle);
            //alert(VChiTietBtp_SizeRow.getLookup().itemById[row.MaBo].MaSize);
            //var sameProduct = Q.tryFirst(this.view.getItems(), x => x.MaXuongChuyen === row.KeyId);
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