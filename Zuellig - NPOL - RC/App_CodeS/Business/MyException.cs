using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using DevExpress.Web;
using DevExpress.XtraCharts;

public class MyException : Exception
{
    public MyException(string message)
        : base(message)
    {
    }
}
   
