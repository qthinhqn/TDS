
namespace Canteen.CantinTHP
{
    using Entities;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Reporting;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;

    //[Report, RequiredPermission(PermissionKeys.General)]
    [Category("CantinTHP"), DisplayName("New Report")]
    public class NewReportReport : IReport, IDataOnlyReport
    {
        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }
        

        public object GetData()
        {
            using (var connection = SqlConnections.NewFor<Entities.TbEmployeeRow>())
            {
                return connection.Query<Item>("spEmployeeList",
                    param: new
                    {
                        startDate = StartDate,
                        endDate = EndDate
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public List<ReportColumn> GetColumnList()
        {
            return ReportColumnConverter.ObjectTypeToList(typeof(Item));
        }

        [BasedOnRow(typeof(TbEmployeeRow), CheckNames = true)]
        public class Item
        {
            public String EmployeeId { get; set; }
            public String EmployeeName { get; set; }
            public Boolean Active { get; set; }
            public DateTime LeftDate { get; set; }
        }
        
    }
}