
namespace Serene3.SpringPrintingConnection.Repositories
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using SpringPrintingConnection.TTblBoBtpRow;
    using System;
    using System.Data;
    using MyRow = Entities.TblBoBtpRow;

    public class TblBoBtpRepository
    {
        private static MyRow.RowFields fld { get { return MyRow.Fields; } }

        public string GetData(IDbConnection connection,
          TblBoBtpRowListRequest request)
        {
            string aaa = "";
            if (request.Note != "")
            {
                var p = new DynamicParameters();
                p.Add("@CardID", Int64.Parse(request.Note));
                p.Add("@MaLo", (request.MaLo == "" ? null : request.MaLo));
                p.Add("@MaKH", null);
                p.Add("@NguoiNhap", null);
                p.Add("@LSLoi", null);
                p.Add("@KeyID", dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("spBo_BTP_Insert", p, commandType: CommandType.StoredProcedure);
                try
                {
                    aaa = p.Get<Int32>("@KeyID").ToString();
                    if (aaa == null)
                        aaa = "";
                }
                catch
                {

                }
            }

            return aaa;
        }

        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MySaveHandler().Process(uow, request, SaveRequestType.Create);
        }

        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MySaveHandler().Process(uow, request, SaveRequestType.Update);
        }

        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request)
        {
            return new MyDeleteHandler().Process(uow, request);
        }

        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRetrieveHandler().Process(connection, request);
        }

        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            return new MyListHandler().Process(connection, request);
        }

        private class MySaveHandler : SaveRequestHandler<MyRow> { }
        private class MyDeleteHandler : DeleteRequestHandler<MyRow> { }
        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }
        private class MyListHandler : ListRequestHandler<MyRow> { }
    }
}