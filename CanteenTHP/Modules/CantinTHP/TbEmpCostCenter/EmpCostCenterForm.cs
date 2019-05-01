
namespace Canteen.CantinTHP.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("CantinTHP.EmpCostCenter")]
    public class EmpCostCenterForm
    {
        [FileUploadEditor, Required]
        public String FileName { get; set; }
    }
}