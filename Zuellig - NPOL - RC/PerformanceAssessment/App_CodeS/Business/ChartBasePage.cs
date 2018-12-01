using System;
using System.Web.UI;
using DevExpress.XtraCharts.Web;

public partial class ChartBasePage : Page {
    Control GetContentHolder() {
        return Form.FindControl("ContentHolder");
    }

    protected override void OnInit(EventArgs e) {
        base.OnInit(e);
        if (FindWebChartControl() != null) {
            Control demoToolbar = LoadControl("~/UserControls/ChartDemoToolbar.ascx");
            if (demoToolbar != null) {
                Control phContent = GetContentHolder();
                if (phContent != null)
                    phContent.Controls.AddAt(0, demoToolbar);
            }
        }
    }
    public virtual WebChartControl FindWebChartControl() {
        Control phContent = GetContentHolder();
        if (phContent == null)
            return null;
        return phContent.FindControl("WebChartControl1") as WebChartControl;
    }
    public virtual bool ShowPaletteComboBox() {
        return true;
    }
}
