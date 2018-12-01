using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Web;
using PAOL.App_Code.Business;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAOL.UserControl
{
    public partial class uc_rptEmpRating_Chartbar :  System.Web.UI.UserControl
    {
        string[] sortFields = new string[] { "EmployeeID", "Rating_Total" };

        Series Series { get { return WebChartControl1.Series[0]; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cbShowLabels.Checked = Series.LabelsVisibility == DefaultBoolean.True;
                PrepareCategoriesComboBox();
                ComboBoxHelper.PrepareComboBox(cbSortOrder, Series.SeriesPointsSorting);
                ComboBoxHelper.PrepareComboBox(cbSortBy, sortFields);
                cbSortBy.SelectedIndex = Series.SeriesPointsSortingKey == SeriesPointKey.Value_1 ? 1 : 0;
                //SelectCategory();
            }
            bool enableSorting = cbSortOrder.SelectedIndex != 0;
            cbSortBy.ClientEnabled = enableSorting;
            lblSortBy.ClientEnabled = enableSorting;
        }
        void SelectCategory()
        {
            if (cbFilterByCategory.Items.Count == 0)
                return;
            string categoryId = (string)cbFilterByCategory.SelectedItem.Value;
            //int id = Convert.ToInt32(categoryId);
            Series.DataFilters[0].Value = categoryId;
        }
        void PrepareCategoriesComboBox()
        {
            SortedList categories = RetrieveCategories();
            if (categories.Count == 0)
            {
                cbFilterByCategory.Enabled = false;
                Series.DataFilters.Clear();
            }
            else
                ComboBoxHelper.PrepareComboBox(cbFilterByCategory, categories);
        }
        void PerformShowLabelsAction()
        {
            Series.LabelsVisibility = cbShowLabels.Checked ? DefaultBoolean.True : DefaultBoolean.False;
            WebChartControl1.CrosshairEnabled = cbShowLabels.Checked ? DefaultBoolean.False : DefaultBoolean.True;
        }
        void PerformFilterByCategoryAction()
        {
            SelectCategory();
        }
        void PerformSortByAction()
        {
            Series.SeriesPointsSortingKey = cbSortBy.SelectedIndex == 1 ? SeriesPointKey.Value_1 : SeriesPointKey.Argument;
        }
        void PerformSortOrderAction()
        {
            Series.SeriesPointsSorting = GetSelectedSortingMode();
        }
        SortingMode GetSelectedSortingMode()
        {
            return (SortingMode)ComboBoxHelper.GetSelectedItem(cbSortOrder, typeof(SortingMode));
        }
        DataView RetrieveDataView()
        {
            Competency_KPIService service = new Competency_KPIService();
            string EmpID = Session["EmployeeID"].ToString();
            int PeriodID = int.Parse(Session["PeriodID"].ToString());
            DataTable dt = service.GetTable_rptEmpKPI("spKPI_GetTable_rptEmpKPI", EmpID, PeriodID);
            return new DataView(dt, "", "", DataViewRowState.CurrentRows);
            //const string selectCommand = "SELECT * from CATEGORIES";
            //using (AccessDataSource dataSource = new AccessDataSource(AccessDataSource1.DataFile, selectCommand))
            //{
            //    dataSource.DataSourceMode = SqlDataSourceMode.DataSet;
            //    return (DataView)dataSource.Select(DataSourceSelectArguments.Empty);
            //}
        }
        DataRowView RetrieveDataRowViewByIndex(int rowIndex)
        {
            DataView dataView = RetrieveDataView();
            return dataView[rowIndex];
        }
        SortedList RetrieveCategories()
        {
            SortedList list = new SortedList();
            DataView dataView = RetrieveDataView();
            if (dataView != null)
            {
                foreach (DataRowView view in dataView)
                {
                    string categoryId = (string)view.Row["EmployeeID"];
                    string category = (string)view.Row["EmployeeName"];
                    list[category] = categoryId;
                }
            }
            return list;
        }
        double CalcMinValue(Series series)
        {
            double min = double.MaxValue;
            foreach (SeriesPoint point in series.Points)
                min = Math.Min(min, point.Values[0]);
            return min;
        }
        double CalcMaxValue(Series series)
        {
            double max = double.MinValue;
            foreach (SeriesPoint point in series.Points)
                max = Math.Max(max, point.Values[0]);
            return max;
        }
        double CalcAverageValue(Series series)
        {
            double sum = 0;
            foreach (SeriesPoint point in series.Points)
                sum += point.Values[0];
            return sum / series.Points.Count;
        }
        protected void WebChartControl1_BoundDataChanged(object sender, EventArgs e)
        {
            ChartTitle dataInfoTitle = WebChartControl1.Titles[0];
            int categoryIndex = cbFilterByCategory.SelectedIndex;
            if (categoryIndex >= 0)
            {
                string categoryName = (string)RetrieveDataRowViewByIndex(categoryIndex)["EmployeeName"];
                dataInfoTitle.Text = "Employee: " + categoryName;
                if (Series.Points.Count > 0)
                {
                    double minValue = Math.Round(CalcMinValue(Series), 2);
                    double maxValue = Math.Round(CalcMaxValue(Series), 2);
                    double averageValue = Math.Round(CalcAverageValue(Series), 2);
                    dataInfoTitle.Text +=
                        "\nMin rating: " + minValue.ToString() +
                        "\nMax rating: " + maxValue.ToString() +
                        "\nAverage rating: " + averageValue.ToString();
                }
            }
            else
                dataInfoTitle.Text = String.Empty;
        }
        protected void WebChartControl1_CustomCallback(object sender, CustomCallbackEventArgs e)
        {
            if (e.Parameter == "ShowLabels")
                PerformShowLabelsAction();
            else if (e.Parameter == "FilterByCategory")
                PerformFilterByCategoryAction();
            else if (e.Parameter == "SortBy")
                PerformSortByAction();
            else if (e.Parameter == "SortOrder")
                PerformSortOrderAction();
        }
    }
}