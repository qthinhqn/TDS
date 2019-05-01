
namespace Canteen.CantinTHP.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("CantinTHP.EmpManager")]
    public class EmpManagerForm
    {
        [FileUploadEditor, Required]
        public String FileName { get; set; }
    }
}