
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
    using MyRepository = Repositories.TbRefDepartmentRepository;
    using MyRow = Entities.TbRefDepartmentRow;

    [RoutePrefix("Services/CantinTHP/TbRefDepartment"), Route("{action}")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class TbRefDepartmentController : ServiceEndpoint
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
            string file = "Template_Department.xlsx";
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
                    var depKey = Convert.ToString(worksheet.Cells[row, 2].Value ?? "");
                    if (depKey.IsTrimmedEmpty())
                        break;

                    var depName = Convert.ToString(worksheet.Cells[row, 3].Value ?? "");
                    if (depName.IsTrimmedEmpty())
                        break;

                    var company = Convert.ToString(worksheet.Cells[row, 4].Value ?? "");
                    if (company.IsTrimmedEmpty())
                        break;
                    
                    var depParent = Convert.ToString(worksheet.Cells[row, 5].Value ?? "");
                    if (depParent.IsTrimmedEmpty())
                        break;

                    Int32? level = null;
                    try
                    {
                        if (worksheet.Cells[row, 6].Value != null)
                            level = Convert.ToInt32(worksheet.Cells[row, 6].Value);
                        else
                            level = null;
                    }
                    catch { }

                    var costcenter = Convert.ToString(worksheet.Cells[row, 7].Value ?? "");

                    var al = uow.Connection.TryFirst<MyRow>(q => q
                        .Select(p.DepKey, p.DepName, p.CompanyKey, p.DepParent, p.iLevel, p.CostCenter, p.KeyId)
                        .Where(p.DepKey == depKey));

                    var new_al = new MyRow
                    {
                        DepKey = depKey,
                        DepName = depName,
                        CompanyKey = company,
                        DepParent = depParent,
                        iLevel = level,
                        CostCenter = costcenter
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
                        if (al.DepName != new_al.DepName || al.DepParent != new_al.DepParent || al.CostCenter != new_al.CostCenter || al.iLevel != new_al.iLevel)
                        {
                            new MyRepository().Update(uow, new SaveRequest<MyRow>
                            {
                                Entity = new_al,
                                EntityId = al.KeyId.Value
                            });

                            response.Updated = response.Updated + 1;
                        }
                        //else
                        //{
                        //    // avoid assignment errors
                        //    al.TrackWithChecks = false;
                        //}
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
