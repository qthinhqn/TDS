using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Web;
using System;
using System.Drawing;

namespace NPOL
{
    public partial class Ad_ViewReportKPI_Pie : ChartBasePage
    {
        Series Series_barPercent { get { return WebChartControl_BarPercent.Series[0]; } }
        PieSeriesLabel Label_barPercent { get { return (PieSeriesLabel)Series_barPercent.Label; } }
        PieSeriesViewBase View_barPercent { get { return (PieSeriesViewBase)Series_barPercent.View; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cbShowLabels.Checked = Series_barPercent.LabelsVisibility != DevExpress.Utils.DefaultBoolean.False;
                ComboBoxHelper.PreparePieLabelsComboBox(cbLabelPosition);
                //ComboBoxHelper.PrepareExplodedPointsComboBox(cbExplodedPoints, Series_barPercent.Points, true);
                //if (Label_barPercent != null && !string.IsNullOrEmpty(Label_barPercent.TextPattern))
                //    cbValueAsPercent.Checked = Label_barPercent.TextPattern.Contains("VP");
                cbLabelPosition.SelectedIndex = 0;
            }
            lblLabelPosition.ClientEnabled = cbShowLabels.Checked;
            cbLabelPosition.ClientEnabled = cbShowLabels.Checked;
            gluLocation.GridView.Width = gluLocation.Width;

            if (Session["Location"].ToString() == "")
            {
                gluLocation.Text = "All";
            }
        }
        void PerformLabelPositionAction()
        {
            PieSeriesLabelPosition position = (PieSeriesLabelPosition)ComboBoxHelper.GetSelectedItem(cbLabelPosition, typeof(PieSeriesLabelPosition));
            Label_barPercent.Position = position;
            Label_barPercent.TextColor = (position.Equals(PieSeriesLabelPosition.Outside) || position.Equals(PieSeriesLabelPosition.TwoColumns)) ? Color.Empty : Color.Black;
            Label_barPercent.Antialiasing = position.Equals(PieSeriesLabelPosition.Radial) || position.Equals(PieSeriesLabelPosition.Tangent);
        }
        void PerformValueAsPercentAction()
        {
            //Label_barPercent.TextPattern = cbValueAsPercent.Checked ? "{A}: {VP:P0}" : "{A}: {V:F1}";
        }
        void PerformExplodedPointsAction()
        {
            //ComboBoxHelper.ApplySelectedExplodingMode(cbExplodedPoints, View_barPercent);
        }
        void PerformShowLabelsAction()
        {
            Series_barPercent.LabelsVisibility = cbShowLabels.Checked ? DefaultBoolean.True : DefaultBoolean.False;
            WebChartControl_BarPercent.ToolTipEnabled = cbShowLabels.Checked ? DefaultBoolean.False : DefaultBoolean.True;
        }
        protected void WebChartControl1_ObjectSelected(object sender, HotTrackEventArgs e)
        {
            Series series = e.Object as Series;
            if (series != null)
            {
                ExplodedSeriesPointCollection explodedPoints = ((PieSeriesViewBase)series.View).ExplodedPoints;
                SeriesPoint point = (SeriesPoint)e.AdditionalObject;
                explodedPoints.ToggleExplodedState(point);
            }
            e.Cancel = series == null;
        }
        protected void WebChartControl1_CustomCallback1(object sender, CustomCallbackEventArgs e)
        {
            if (e.Parameter == "LabelPosition")
                PerformLabelPositionAction();
            else if (e.Parameter == "ValueAsPercent")
                PerformValueAsPercentAction();
            else if (e.Parameter == "ExplodedPoints")
                PerformExplodedPointsAction();
            else if (e.Parameter == "ShowLabels")
                PerformShowLabelsAction();
        }

        protected void gluLocation_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string location = gluLocation.Value == null ? "" : gluLocation.Value.ToString();
                Session["Location"] = (location == "All" ? "" : location);
                ASPxGridView1.DataBind();
                WebChartControl_BarPercent.DataBind();
                gluLocation.Text = (location == "" ? "All" : location);
            }
            catch (Exception ex)
            {
                Session["Location"] = "All";
            }
        }
    }
}