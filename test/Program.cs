using Copernicus.ShadowsocksURi;
using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(string.Join(",", SSURi.Parse(Console.ReadLine())));
                Console.WriteLine(SSEntity.encryptStr);
                //Console.WriteLine(SSURL.Create("bf-cfb","233","2.33.33.33",2333));
                Console.ReadLine();
            }
        }
    }
}
