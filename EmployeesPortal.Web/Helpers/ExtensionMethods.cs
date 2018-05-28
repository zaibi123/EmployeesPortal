using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace computan.lawpreviewforms.Helpers
{
    public static class ExtensionMethods
    {
        public static bool HasFile(this HttpPostedFileBase file)
        {
            return file != null && file.ContentLength > 0;
        }
    }
}