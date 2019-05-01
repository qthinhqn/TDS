
namespace Canteen.CantinTHP.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("CantinTHP.EmpDayOff")]
    public class EmpDayOffForm
    {
        [FileUploadEditor, Required]
        public String FileName { get; set; }
    }
}