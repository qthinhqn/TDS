
namespace Canteen.CantinTHP.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("CantinTHP.RefDepartment")]
    public class RefDepartmentForm
    {
        [FileUploadEditor, Required]
        public String FileName { get; set; }
    }
}