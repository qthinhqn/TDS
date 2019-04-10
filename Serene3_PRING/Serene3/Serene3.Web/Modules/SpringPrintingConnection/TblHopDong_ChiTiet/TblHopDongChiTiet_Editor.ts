/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblHopDongChiTiet_Editor extends Common.GridEditorBase<TblHopDong_ChiTietRow> {
        protected getColumnsKey() { return "SpringPrintingConnection.TblHopDong_ChiTiet"; }
        protected getDialogType() { return TblHopDong_ChiTietDialog; }
        protected getLocalTextPrefix() { return TblHopDong_ChiTietRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
        protected getAddButtonCaption() { return "Add";}

        validateEntity(row, id) {
            //alert(Q.toId(id));
            ////row.KeyId = Q.toId(row.KeyId);

            //var sameProduct = Q.tryFirst(this.view.getItems(), x => (x.MaBtp = row.MaBtp) && (x.MaSize = row.MaSize) );
            //alert(sameProduct);
            //if (sameProduct && this.id(sameProduct) !== id) {
            //    Q.alert('This Contract is already in order details!');
            //    return false;
            //}
            //row.MaMauTenMau = "aaa";
            var MaBtp = Q.toId(row.MaBtp);
            if (MaBtp != null) {
                row.MaBtpMotaBtp = TblBanThanhPhamRow.getLookup().itemById[row.MaBtp].MotaBtp;
            }
            else {
                row.MaBtpMotaBtp = null;
            }
           // row.MaBtpMotaBtp = TblBanThanhPhamRow.getLookup().itemById[row.MaBtp].MotaBtp;
            var MaMau = Q.toId(row.MaMau);
            if (MaMau != null) {
                row.MaMauTenMau = TblRefMauRow.getLookup().itemById[row.MaMau].TenMau;
            }
            else {
                row.MaMauTenMau = null;
            }
            var MaSize = Q.toId(row.MaSize);
            if (MaSize != null) {
                row.MaSizeTenSize = TblRefSizeRow.getLookup().itemById[row.MaSize].TenSize;
            }
            else {
                row.MaSizeTenSize = null;
            }
            var MaStyle = Q.toId(row.MaStyle);
            if (MaStyle != null) {
                row.MaStyleTenStyle = TblRefStyleRow.getLookup().itemById[row.MaStyle].TenStyle;
            }
            else {
                row.MaStyleTenStyle = null;
            }
            
            return true;
        }
    }
}