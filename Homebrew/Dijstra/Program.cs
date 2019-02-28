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
            var watch = new System.Diagnostics.Stopwatch();
            
            Map TestMap = new DiagonalMap(200, 200);
            MapPrinter TestPrinter = new MapPrinter();
            Player TestDude = new AStjerne();
            TestMap.MakeEverythingFloor();
            TestMap.BuildWalls();
            TestMap.SetGoal(100, 20);
            watch.Start();
            TestDude.FindPath(TestMap, 1, 1);
            watch.Stop();
            //TestPrinter.Print2DMap(TestMap);
            Console.WriteLine("It took "+ watch.Elapsed.Milliseconds + " and " + TestDude.NodesVisited +" Nodes Visited");

            Console.ReadKey();
        }
    }
}
