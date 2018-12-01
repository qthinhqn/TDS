using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NPOL.UserControl
{
    public partial class uc_KPI_Indicator : System.Web.UI.UserControl
    {
        private int step;
        private int current;
        public int Step
        {
            get
            {
                return step;
            }
            set
            {
                step = value;
            }
        }
        public int Current
        {
            get
            {
                return current;
            }
            set
            {
                current = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            PreLoad();
        }
        public void PreLoad()
        {
            this.FindControl("Step_1_Current_1").Visible = false;

            this.FindControl("Step_2_Current_1").Visible = false;
            this.FindControl("Step_2_Current_2").Visible = false;

            this.FindControl("Step_3_Current_1").Visible = false;
            this.FindControl("Step_3_Current_2").Visible = false;
            this.FindControl("Step_3_Current_3").Visible = false;

            this.FindControl("Step_4_Current_1").Visible = false;
            this.FindControl("Step_4_Current_2").Visible = false;
            this.FindControl("Step_4_Current_3").Visible = false;
            this.FindControl("Step_4_Current_4").Visible = false;
            
            switch (step)
            {
                case 1:
                    this.FindControl("Step_1_Current_1").Visible = true;
                    break;

                case 2:
                    if (current == 1)
                        this.FindControl("Step_2_Current_1").Visible = true;
                    else if (current == 2)
                        this.FindControl("Step_2_Current_2").Visible = true;
                    break;

                case 3:
                    if (current == 1)
                        this.FindControl("Step_3_Current_1").Visible = true;
                    else if (current == 2)
                        this.FindControl("Step_3_Current_2").Visible = true;
                    else if (current == 3)
                        this.FindControl("Step_3_Current_3").Visible = true;
                    break;

                case 4:
                    if (current == 1)
                        this.FindControl("Step_4_Current_1").Visible = true;
                    else if (current == 2)
                        this.FindControl("Step_4_Current_2").Visible = true;
                    else if (current == 3)
                        this.FindControl("Step_4_Current_3").Visible = true;
                    else if (current == 4)
                        this.FindControl("Step_4_Current_4").Visible = true;
                    break;

                default:
                    break;

            }

            //Load controll

        }
    }
}