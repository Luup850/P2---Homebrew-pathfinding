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
            Player TestDude = new Player();
            TestMap.MakeEverythingFloor();
            TestMap.BuildWalls();
            TestMap.SetGoal(18, 19);
            TestMap.MapArray[1, 14] = new Wall(1,14);
            TestMap.MapArray[2, 14] = new Wall(2, 14);
            TestMap.MapArray[3, 14] = new Wall(3, 14);
            TestMap.MapArray[4, 14] = new Wall(4, 14);
            TestMap.MapArray[4, 13] = new Wall(4, 13);
            TestMap.MapArray[4, 12] = new Wall(4, 12);
            TestMap.MapArray[3, 12] = new Wall(3, 12);

            TestDude.FindPath(TestMap, 1, 1);
            TestPrinter.Print2DMap(TestMap);

            Console.ReadKey();
        }
    }
}
