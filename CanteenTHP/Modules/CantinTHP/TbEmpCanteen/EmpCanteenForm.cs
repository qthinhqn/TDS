
namespace Canteen.CantinTHP.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("CantinTHP.EmpCanteen")]
    public class EmpCanteenForm
    {
        [FileUploadEditor, Required]
        public String FileName { get; set; }
    }
}