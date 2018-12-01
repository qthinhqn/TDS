using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Threading;
using System.Globalization;
using System.Data;

namespace NPOL.Report
{
    public partial class AnnualLeave : DevExpress.XtraReports.UI.XtraReport
    {
        public AnnualLeave()
        {
            InitializeComponent();
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");     
        }

        private void xrTableCell196_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("EmployedDate");

            if (!value.ToString().Equals(""))
            {
                DateTime dt = Convert.ToDateTime(value);
                lb.Text = new DateTime(dt.Year, dt.Month, dt.Day).ToString("dd/MM/yyyy",new CultureInfo("en-US"));
            }
        }

        private void xrTableCell197_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Seniority");

            if (!value.ToString().Equals(""))
            {                
                lb.Text = Convert.ToDouble(value).ToString("n1", new CultureInfo("en-US"));
                
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell200_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("TotalALInit");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell201_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Jan_AL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell202_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Jan_SL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell203_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Jan_UP");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell204_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Jan_UN");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell205_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Feb_AL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell206_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Feb_SL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell207_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Feb_UP");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell208_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Feb_UN");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell209_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Mar_AL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell210_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Mar_SL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell211_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Mar_UP");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell212_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Mar_UN");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell213_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Apr_AL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell214_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Apr_SL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell215_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Apr_UP");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell216_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Apr_UN");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell217_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("May_AL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell218_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("May_SL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell219_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("May_UP");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell220_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("May_UN");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell221_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Jun_AL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell226_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Jun_SL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell227_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Jun_UP");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell228_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Jun_UN");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell229_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Aug_AL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell230_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Aug_SL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell231_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Aug_UP");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell232_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Aug_UN");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell233_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Sep_AL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell234_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Sep_SL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell235_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Sep_UP");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell236_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Sep_UN");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell237_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Oct_AL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell238_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Oct_SL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell239_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Oct_UP");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell240_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Oct_UN");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell242_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Nov_AL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell243_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Nov_SL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell244_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Nov_UP");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell241_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Nov_UN");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell245_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Dec_AL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell246_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Dec_SL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell247_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Dec_UP");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell248_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("Dec_UN");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell249_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("TotalAL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell250_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("TotalSL");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell251_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("TotalUP");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell252_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("TotalUN");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell253_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel lb = sender as XRLabel;
            object value = this.GetCurrentColumnValue("ALBalance");

            if (!value.ToString().Equals(""))
            {
                lb.Text = Convert.ToDouble(value).ToString("n2", new CultureInfo("en-US"));
            }

            if (string.IsNullOrWhiteSpace(lb.Text))
            {
                lb.Text = "-";
            }

            if (string.Compare(lb.Text, "0.00", true) == 0 || string.Compare(lb.Text, "0,00", true) == 0)
            {
                lb.Text = "-";
            }
        }

        private void xrTableCell198_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //khSqlServerProvider provider = new khSqlServerProvider(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ZuelligConnection"].ConnectionString);
            //provider.CommandText = "Select SectionName from tblEmployee where EmployeeID = @EmpID";
            //provider.ParameterCollection = new string[] {"@EmpID" };
            //provider.ValueCollection = new object[] {GetCurrentColumnValue("EmployeeID") };
            //DataTable dt = provider.GetDataTable();
            //if (dt.Rows.Count > 0)
            //{
            //    XRLabel lb = sender as XRLabel;
            //    lb.Text = dt.Rows[0]["SectionName"].ToString();
            //}
            //provider.CloseConnection();
        }

    }
}
