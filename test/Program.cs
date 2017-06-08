using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Copernicus.SSURL;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(string.Join(",", SSURL.Parse(Console.ReadLine())));
                Console.ReadLine();
            }
        }
    }
}
