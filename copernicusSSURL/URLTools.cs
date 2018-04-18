using System;
using System.Text;
using static Copernicus.ShadowsocksURi.SSEntity;

namespace Copernicus.ShadowsocksURi
{
    public class SSEntity
    {
        public string name;
        public string encryptStr;
        public string passStr;
        public string serverIpStr;
        public int port;
    }

    public class SSURi
    {
        public static SSEntity Parse(string ssURL)
        {
            string urlString;
            SSEntity entity = new SSEntity();

            if (!ssURL.Contains("#"))
            {
                urlString = deCodeBase64(ssURL.Replace("ss://", ""));
            }
            else
            {
                entity.name = ssURL.Split('#')[1];
                ssURL = ssURL.Split('#')[0];
                urlString = deCodeBase64(ssURL.Replace("ss://", ""));
            }

            string[] ssArray = urlString.Split(new char[2] {'@', ':'});

            entity.encryptStr = ssArray[0];
            entity.passStr = ssArray[1];
            entity.serverIpStr = ssArray[2];
            entity.port = Convert.ToInt32(ssArray[3]);

            return entity;
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
