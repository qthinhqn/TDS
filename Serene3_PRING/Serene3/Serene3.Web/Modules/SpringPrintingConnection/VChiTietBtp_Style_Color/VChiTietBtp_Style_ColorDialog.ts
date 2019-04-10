
namespace Serene3.SpringPrintingConnection {

    @Serenity.Decorators.registerClass()
    export class VChiTietBtp_Style_ColorDialog extends Serenity.EntityDialog<VChiTietBtp_Style_ColorRow, any> {
        protected getFormKey() { return VChiTietBtp_Style_ColorForm.formKey; }
        protected getIdProperty() { return VChiTietBtp_Style_ColorRow.idProperty; }
        protected getLocalTextPrefix() { return VChiTietBtp_Style_ColorRow.localTextPrefix; }
        protected getNameProperty() { return VChiTietBtp_Style_ColorRow.nameProperty; }
        protected getService() { return VChiTietBtp_Style_ColorService.baseUrl; }

        protected form = new VChiTietBtp_Style_ColorForm(this.idPrefix);

    }
}