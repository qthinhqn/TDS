/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class TblBo_BTPEditor extends Common.GridEditorBase<TblBo_BTPRow> {
        protected getColumnsKey() { return "SpringPrintingConnection.TblBo_BTP"; }
        protected getDialogType() { return TblBo_BTPDialog; }
        protected getLocalTextPrefix() { return TblBo_BTPRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }

        validateEntity(row, id) {
            //row.MaLo = Q.toId(row.MaLo);

            //var sameProduct = Q.tryFirst(this.view.getItems(), x => x.MaLo === row.MaLo);
            //if (sameProduct && this.id(sameProduct) !== id) {
            //    Q.alert('This product is already in order details!');
            //    return false;
            //}
            //alert(TblRefMauRow.getLookup().itemById[row.MaMau].TenMau);
            //alert(row.MaBtp.value);
            var MaBtp = Q.toId(row.MaBtp);
            if (MaBtp != null) {
                row.MaBtpMotaBtp = TblBanThanhPhamRow.getLookup().itemById[row.MaBtp].MotaBtp;
            }
            else {
                row.MaBtpMotaBtp = null;
               }
            var MaMau = Q.toId(row.MaMau);
            if (MaMau != null) { 
                row.MaMauTenMau = TblRefMauRow.getLookup().itemById[row.MaMau].TenMau;
            }
            else
            {
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