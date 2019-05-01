
namespace Canteen.CantinTHP.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("CantinTHP.EmpCostTemp")]
    public class EmpCostTempForm
    {
        [FileUploadEditor, Required]
        public String FileName { get; set; }
    }
}