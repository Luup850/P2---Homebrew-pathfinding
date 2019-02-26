using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijstra
{
    class Program
    {
        static void Main(string[] args)
        {
            Map TestMap = new Map(20, 20);
            MapPrinter TestPrinter = new MapPrinter();
            TestMap.MakeEverythingFloor();
            TestMap.BuildWalls();
            TestPrinter.Print2DMap(TestMap);

            Console.ReadKey();
        }
    }
}
