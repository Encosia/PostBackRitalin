using System;
using System.Collections.Generic;
using System.Text;

namespace PostBackRitalin
{
    public class Utilities
    {
        public static string VirtualURLHelper(string URL)
        {
            if (URL.StartsWith("~"))
                return System.Web.VirtualPathUtility.ToAbsolute(URL);
            else
                return URL;
        }
    }

}
