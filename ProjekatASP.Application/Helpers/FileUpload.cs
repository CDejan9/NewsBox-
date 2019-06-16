using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatASP.Application.Helpers
{
    public class FileUpload
    {
        public static IEnumerable<string> ValidExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".gif" };
    }
}
