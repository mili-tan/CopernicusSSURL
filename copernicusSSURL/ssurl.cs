using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Copernicus.SSURL
{
    public class SSURL
    {

        public static string[] Parse(string ssURL)
        {
            string urlString = decodeBase64(ssURL.Replace("ss://", ""));
            string[] ssArray = urlString.Split(new char[2] {'@', ':'});
            return ssArray;
        }

        private static string decodeBase64(string result)
        {
            string deCode = "";
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                deCode = Encoding.UTF8.GetString(bytes);
            }
            catch
            {
                deCode = result;
            }
            return deCode;
        }
    }
}
