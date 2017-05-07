using System;
using System.IO;

namespace KDS.Presentation.Seedwork.Extensions
{
    public static class PathExtensions
    {
        public static string ToImageBase64(this string path)
        {
            var byteArray = File.ReadAllBytes(path);
            var base64 = Convert.ToBase64String(byteArray);
            return string.Format("data:image/gif;base64,{0}", base64);
        }
    }
}
