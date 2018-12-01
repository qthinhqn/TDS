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
    public partial class Xtra_AtSite : DevExpress.XtraReports.UI.XtraReport
    {
        public Xtra_AtSite()
        {
            InitializeComponent();            
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");     
        }

        private void getData()
        {
            
        }
       

        private void xrTitle_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            int month = Convert.ToInt32(lbMonthID.Text);
            if (month < 10)
            {
                xrTitle.Text = "PHIẾU LƯƠNG THÁNG 0" + lbMonthID.Text + "/" + lbYearID.Text;
            }
            else
            {
                xrTitle.Text = "PHIẾU LƯƠNG THÁNG " + lbMonthID.Text + "/" + lbYearID.Text;
            }
            
        }

        private void xrLabel14_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.00", true) == 0 || string.Compare(str, "0,00", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel15_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.00", true) == 0 || string.Compare(str, "0,00", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel16_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.00", true) == 0 || string.Compare(str, "0,00", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel18_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;

            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.00", true) == 0 || string.Compare(str, "0,00", true) == 0)
            {
                label.Text = "-";
            }           
        }

        private void xrLabel45_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0,0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel44_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0,0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel43_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0,0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel42_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel50_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel49_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel48_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel31_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel55_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel54_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel53_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel52_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel17_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.00", true) == 0 || string.Compare(str, "0,00", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel29_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel58_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel60_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel62_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel65_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel76_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel74_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel78_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel80_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel82_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel84_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel97_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel86_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel90_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel46_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel66_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel92_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel99_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel93_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel95_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel101_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0,0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel103_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0,0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
        }

        private void xrLabel33_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRLabel label = (XRLabel)sender;
            if (string.IsNullOrWhiteSpace(label.Text))
            {
                label.Text = "-";
            }
            string str = label.Text;
            if (string.Compare(str, "0.0", true) == 0 || string.Compare(str, "0.0", true) == 0)
            {
                label.Text = "-";
            }
            
        }

        private void xrLabel2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
                   
            
        }
        
    }
}
