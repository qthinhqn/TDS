
namespace Canteen.CantinTHP.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("CantinTHP.RefCostCenter")]
    public class RefCostCenterForm
    {
        [FileUploadEditor, Required]
        public String FileName { get; set; }
    }
}