
namespace Serene3.SpringPrintingConnection.Repositories
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using SpringPrintingConnection.TblXuatKhoChiTiet;
    using System;
    using System.Data;
    using MyRow = Entities.TblXuatKhoChiTietRow;

    public class TblXuatKhoChiTietRepository
    {
        private static MyRow.RowFields fld { get { return MyRow.Fields; } }
        public TblXuatKhoChiTietListResponse GetData(IDbConnection connection,
          TblXuatKhoChiTietListRequest request)
        {
            TblXuatKhoChiTietListResponse result = new TblXuatKhoChiTietListResponse();

            if (request.Note != "")
            {
                var p = new DynamicParameters();
                p.Add("@CardID", Int64.Parse(request.Note));
                p.Add("@MaPhieuXuat", (request.MaBo == "" ? null : request.MaBo));
                p.Add("@NguoiNhap", null);
                p.Add("@KeyID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("@ErrorCode", dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spBo_BTP_XuatKH", p, commandType: CommandType.StoredProcedure);
                try
                {
                    try
                    {
                        result.KeyID = Convert.ToString(p.Get<Int32>("@KeyID"));
                    }
                    catch
                    { result.KeyID = ""; }
                    try
                    {
                        result.ErrorCode = Convert.ToString(p.Get<Int32>("@ErrorCode"));
                    }
                    catch
                    { result.ErrorCode = ""; }
                    //if (aaa == null)
                    //    aaa = "";
                }
                catch
                {

                }
            }

            return result;
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