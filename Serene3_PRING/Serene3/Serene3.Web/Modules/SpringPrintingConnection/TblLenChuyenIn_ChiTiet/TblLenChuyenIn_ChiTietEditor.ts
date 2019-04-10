/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblLenChuyenIn_ChiTietEditor extends Common.GridEditorBase<TblLenChuyenIn_ChiTietRow> {
        protected getColumnsKey() { return "SpringPrintingConnection.TblLenChuyenIn_ChiTiet"; }
        protected getDialogType() { return TblLenChuyenIn_ChiTietDialog; }
        protected getLocalTextPrefix() { return TblLenChuyenIn_ChiTietRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }

        validateEntity(row, id) {
            //row.KeyId = Q.toId(row.KeyId);
           // alert(VChiTietBtp_StyleRow.getLookup().itemById[row.MaBo].MaStyle);
           // alert(VChiTietBtp_SizeRow.getLookup().itemById[row.MaBo].MaSize);
            //var sameProduct = Q.tryFirst(this.view.getItems(), x => x.MaLenChuyen === row.KeyId);
            //if (sameProduct && this.id(sameProduct) !== id) {
            //    Q.alert('This Contract is already in order details!');
            //    return false;
            //}
            //row.MaBtpMotaBtp = TblBo_BTPRow.getLookup().itemById[row.MaBtp].MotaBtp;
            row.CT_MaBTP = VChiTietBtpRow.getLookup().itemById[row.MaBo].MaBtp;
            row.CT_MaMau = VChiTietBtp_Style_ColorRow.getLookup().itemById[row.MaBo].MaMau;
            row.CT_MaStyle = VChiTietBtp_StyleRow.getLookup().itemById[row.MaBo].MaStyle;
            row.CT_MaSize = VChiTietBtp_SizeRow.getLookup().itemById[row.MaBo].MaSize;

            //var MaBtp = Q.toId(row.MaBtp.value);
            //if (MaBtp != null) {
            //    row.CT_MaBTP = TblBanThanhPhamRow.getLookup().itemById[row.MaBtp].MotaBtp;
            //}
            //else {
            //    row.CT_MaBTP = null;
            //}

            //var MaMau = Q.toId(row.MaMau.value);
            //if (MaMau != null) {
            //    row.CT_MaMau = TblRefMauRow.getLookup().itemById[row.MaMau].TenMau;
            //}
            //else {
            //    row.CT_MaMau = null;
            //}
            //var MaSize = Q.toId(row.MaSize.value);
            //if (MaSize != null) {
            //    row.CT_MaSize = TblRefSizeRow.getLookup().itemById[row.MaSize].TenSize;
            //}
            //else {
            //    row.CT_MaSize = null;
            //}

            //var MaStyle = Q.toId(row.MaStyle.value);
            //if (MaStyle != null) {
            //    row.CT_MaStyle = TblRefStyleRow.getLookup().itemById[row.MaStyle].TenStyle;
            //}
            //else {
            //    row.CT_MaStyle = null;
            //}
            //row.MaSizeTenSize = TblBo_BTPRow.getLookup().itemById[row.MaSize].TenSize;
            //row.MaStyleTenStyle = TblBo_BTPRow.getLookup().itemById[row.MaStyle].TenStyle;
            return true;
        }
    }
}