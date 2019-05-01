
namespace Canteen.CantinTHP.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("CantinTHP.EmpShift")]
    public class EmpShiftForm
    {
        [FileUploadEditor, Required]
        public String FileName { get; set; }
    }
}