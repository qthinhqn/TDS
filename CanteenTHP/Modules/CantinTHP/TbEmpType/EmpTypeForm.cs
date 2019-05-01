
namespace Canteen.CantinTHP.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("CantinTHP.EmpType")]
    public class EmpTypeForm
    {
        [FileUploadEditor, Required]
        public String FileName { get; set; }
    }
}