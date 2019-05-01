
namespace Canteen.CantinTHP.Endpoints
{
    using OfficeOpenXml;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Web.Mvc;
    using MyRepository = Repositories.TbEmpDepartmentRepository;
    using MyRow = Entities.TbEmpDepartmentRow;

    [RoutePrefix("Services/CantinTHP/TbEmpDepartment"), Route("{action}")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class TbEmpDepartmentController : ServiceEndpoint
    {
        [HttpPost, AuthorizeCreate(typeof(MyRow))]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MyRepository().Create(uow, request);
        }

        [HttpPost, AuthorizeUpdate(typeof(MyRow))]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MyRepository().Update(uow, request);
        }
 
        [HttpPost, AuthorizeDelete(typeof(MyRow))]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request)
        {
            return new MyRepository().Delete(uow, request);
        }

        [HttpPost]
        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRepository().Retrieve(connection, request);
        }

        [HttpPost]
        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            return new MyRepository().List(connection, request);
        }

        public FileContentResult TemplateExcel(IDbConnection connection, ListRequest request)
        {
            string file = "Template_EmpDepartment.xlsx";
            string fullPath = Path.Combine(Server.MapPath("~/temp/Imports"), file);
            var fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return ExcelContentResult.Create(fileBytes, file);
        }

        [HttpPost]
        public ExcelImportResponse ExcelImport(IUnitOfWork uow, ExcelImportRequest request)
        {
            request.CheckNotNull();
            Check.NotNullOrWhiteSpace(request.FileName, "filename");

            UploadHelper.CheckFileNameSecurity(request.FileName);

            if (!request.FileName.StartsWith("temporary/"))
            {
                throw new ArgumentOutOfRangeException("filename");
            }

            ExcelPackage ep = new ExcelPackage();
            using (var fs = new FileStream(UploadHelper.DbFilePath(request.FileName), FileMode.Open, FileAccess.Read))
            {
                ep.Load(fs);
            }

            var p = MyRow.Fields;

            var response = new ExcelImportResponse();
            response.ErrorList = new List<string>();

            var worksheet = ep.Workbook.Worksheets[1];
            for (var row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                try
                {
                    var EmployeeID = Convert.ToString(worksheet.Cells[row, 2].Value ?? "");
                    if (EmployeeID.IsTrimmedEmpty())
                        break;

                    var department = Convert.ToString(worksheet.Cells[row, 3].Value ?? "");
                    if (department.IsTrimmedEmpty())
                        break;

                    DateTime? datechange = null;
                    try
                    {
                        if (worksheet.Cells[row, 4].Value != null)
                            datechange = Convert.ToDateTime(worksheet.Cells[row, 4].Value);
                        else
                            datechange = null;
                    }
                    catch { }

                    var remark = Convert.ToString(worksheet.Cells[row, 5].Value ?? "");

                    var al = uow.Connection.TryFirst<MyRow>(q => q
                        .Select(p.EmpId, p.DepKey, p.DateChange, p.Remarks, p.KeyId)
                        .Where(p.EmpId == EmployeeID && p.DepKey == department && p.DateChange == datechange.Value));

                    var new_al = new MyRow
                    {
                        EmpId = EmployeeID,
                        DepKey = department,
                        DateChange = datechange,
                        Remarks = remark
                    };

                    if (al == null)
                    {
                        // insert new object
                        new MyRepository().Create(uow, new SaveRequest<MyRow>
                        {
                            Entity = new_al
                        });

                        response.Inserted = response.Inserted + 1;
                    }
                    else
                    {
                        // check update
                    }
                }
                catch (Exception ex)
                {
                    response.ErrorList.Add("Exception on Row " + row + ": " + ex.Message);
                }
            }

            return response;
        }

    }
}
