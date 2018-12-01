using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Globalization;

namespace PAOL
{
    public class Class1:System.Web.UI.Page
    {
        protected override void InitializeCulture()
        {
            string culture = string.Empty;
            string lang = Convert.ToString(Session["lang"]);

            if (Session["lang"] == null)
            {
                culture = "vi-VN";
            }
            else
            {
                if (lang.ToLower().CompareTo("en") == 0 || string.IsNullOrEmpty(culture))
                {
                    culture = "en-US";
                }
                if (lang.ToLower().CompareTo("vi") == 0)
                {
                    culture = "vi-VN";
                }
            }

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);

            base.InitializeCulture();
        }
    }
}