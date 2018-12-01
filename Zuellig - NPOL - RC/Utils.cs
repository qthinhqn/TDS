using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPxUploadDemo
{
    public static class Utils
    {
        public static string GetVersionSuffix()
        {
            return AssemblyInfo.Version.Replace(".", "_");
        }
    }
}