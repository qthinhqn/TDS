using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAOL.App_Code.Data
{
    public class DataAccessException : Exception
    {
        public DataAccessException() { }
        public DataAccessException(string message)
            : base(message)
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}