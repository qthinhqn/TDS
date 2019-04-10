
namespace Serene3.SpringPrintingConnection.Endpoints
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Reporting;
    using Serenity.Services;
    using Serenity.Web;
    using SpringPrintingConnection.TTblBoBtpRow;
    using System;
    using System.Data;
    using System.Web.Mvc;
    using MyRepository = Repositories.TblBoBtpRepository;
    using MyRow = Entities.TblBoBtpRow;

    [RoutePrefix("Services/SpringPrintingConnection/TblBoBtp"), Route("{action}")]
    [ConnectionKey(typeof(MyRow)), ServiceAuthorize(typeof(MyRow))]
    public class TblBoBtpController : ServiceEndpoint
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

        public string GetData(IDbConnection connection, TblBoBtpRowListRequest request)
        {
            return new MyRepository().GetData(connection, request);
        }
        public FileContentResult ListExcel(IDbConnection connection, ListRequest request)
        {
            var data = List(connection, request).Entities;
            var report = new DynamicDataReport(data, request.IncludeColumns, typeof(Columns.TblBoBtpColumns));
            var bytes = new ReportRepository().Render(report);
            return ExcelContentResult.Create(bytes, "TblBoBtpList_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx");
        }
    }
}
