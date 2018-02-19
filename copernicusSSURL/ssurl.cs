using System;
using System.Text;
using static Copernicus.SSURL.SSURLTools.SSEntity;

namespace Copernicus.SSURL
{
    public class SSURLTools
    {
        public class SSEntity
        {
            public static string name;
            public static string encryptStr;
            public static string passStr;
            public static string serverIpStr;
            public static int port;
        }

        public static string[] Parse(string ssURL)
        {
            string urlString;

            if(!ssURL.Contains("#"))
            {
                urlString = deCodeBase64(ssURL.Replace("ss://", ""));
            }
            else
            {
                name = ssURL.Split('#')[1];
                ssURL = ssURL.Split('#')[0];
                urlString = deCodeBase64(ssURL.Replace("ss://", ""));
            }

            string[] ssArray = urlString.Split(new char[2] {'@', ':'});

            encryptStr = ssArray[0];
            passStr = ssArray[1];
            serverIpStr = ssArray[2];
            port = Convert.ToInt32(ssArray[3]);

            return ssArray;
        }

        public static string Create(string encryptStr, string passStr, string serverIpStr, int port)
        {
            string linkStr = string.Format("{0}:{1}@{2}:{3}", encryptStr, passStr, serverIpStr, port.ToString());
            string ssUrlStr = string.Format("ss://{0}",enCodeBase64(linkStr));
            return ssUrlStr;
        }

        private static string enCodeBase64(string sourceStr)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(sourceStr); 
            string enCode = Convert.ToBase64String(bytes);
            return enCode;
        }

        private static string deCodeBase64(string resultStr)
        {
            byte[] bytes = Convert.FromBase64String(resultStr);
            string deCode = Encoding.UTF8.GetString(bytes);
            return deCode;
        }
    }
}
