
namespace Canteen.CantinTHP.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("CantinTHP.EmpDepartment")]
    public class EmpDepartmentForm
    {
        [FileUploadEditor, Required]
        public String FileName { get; set; }
    }
}