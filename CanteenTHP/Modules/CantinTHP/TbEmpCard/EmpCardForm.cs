
namespace Canteen.CantinTHP.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("CantinTHP.EmpCard")]
    public class EmpCardForm
    {
        [FileUploadEditor, Required]
        public String FileName { get; set; }
    }
}