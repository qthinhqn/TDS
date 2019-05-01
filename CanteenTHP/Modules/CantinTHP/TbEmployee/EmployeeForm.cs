
namespace Canteen.CantinTHP.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("CantinTHP.Employee")]
    public class EmployeeForm
    {
        [FileUploadEditor, Required]
        public String FileName { get; set; }
    }
}