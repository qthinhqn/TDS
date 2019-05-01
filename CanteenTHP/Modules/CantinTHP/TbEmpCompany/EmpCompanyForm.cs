
namespace Canteen.CantinTHP.Forms
{
    using Serenity.ComponentModel;
    using System;

    [FormScript("CantinTHP.EmpCompany")]
    public class EmpCompanyForm
    {
        [FileUploadEditor, Required]
        public String FileName { get; set; }
    }
}