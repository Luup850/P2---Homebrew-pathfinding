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
            
            Map TestMap = new Map(200, 45);
            MapPrinter TestPrinter = new MapPrinter();
            //Player TestDude = new Brodforst();
            Player TestHomebrew = new Player();
            Player TestAstjerne = new AStjerne();
            Player TestBrodforst = new Brodforst();
            TestMap.MakeEverythingFloor();
            TestMap.BuildWalls();
            TestMap.SetGoal(198, 43);

            
            TestMap.TrumpXAxis(0, 22, 198);
            TestMap.TrumpXAxis(0, 10, 198);
            TestMap.TrumpXAxis(0, 35, 198);

            TestMap.TrumpYAxis(35, 0, 44);
            TestMap.TrumpYAxis(135, 0, 44);
            TestMap.TrumpYAxis(80, 0, 44);
            TestMap.TrumpYAxis(170, 0, 44);

            TestMap.MapArray[22, 35] = new Floor(22, 35);
            TestMap.MapArray[80, 8] = new Floor(80, 8);
            TestMap.MapArray[194, 35] = new Floor(194, 35);
            TestMap.MapArray[198, 10 ] = new Floor(198, 10);
            TestMap.MapArray[196, 22] = new Floor(196, 22);

            TestMap.MapArray[10, 35] = new Floor(10, 35);
            TestMap.MapArray[15, 10] = new Floor(15, 10);
            TestMap.MapArray[2, 22] = new Floor(2, 22);

            TestMap.MapArray[100, 22] = new Floor(100, 22);
            TestMap.MapArray[35, 37] = new Floor(35, 37);
            TestMap.MapArray[135, 2] = new Floor(135, 2);
            TestMap.MapArray[170, 9] = new Floor(170, 9);
            TestMap.MapArray[35, 4] = new Floor(35, 4);
            /*watch.Start();
            TestDude.FindPath(TestMap, 1, 1);
            watch.Stop();
            */
            watch.Reset();
            watch.Start();
            TestHomebrew.FindPath(TestMap, 1, 1);
            watch.Stop();
            Console.WriteLine("It took " + watch.Elapsed.Milliseconds + " ms and " + TestHomebrew.NodesVisited + " Nodes Visited for Homebrew" + 
                " Amount of nodes in final route is " + TestHomebrew.Route.Count +" nodes long" );
            TestMap.MapArray[1, 1].Symbol = 'S';
            TestMap.MapArray[198, 43].Symbol = 'M';

            TestPrinter.Print2DMap(TestMap);
            TestMap.MakeEverythingFloor();
            TestMap.BuildWalls();
            TestMap.TrumpXAxis(0, 22, 198);
            TestMap.TrumpXAxis(0, 10, 198);
            TestMap.TrumpXAxis(0, 35, 198);

            TestMap.TrumpYAxis(35, 0, 44);
            TestMap.TrumpYAxis(135, 0, 44);
            TestMap.TrumpYAxis(80, 0, 44);
            TestMap.TrumpYAxis(170, 0, 44);

            TestMap.MapArray[22, 35] = new Floor(22, 35);
            TestMap.MapArray[80, 8] = new Floor(80, 8);
            TestMap.MapArray[194, 35] = new Floor(194, 35);
            TestMap.MapArray[198, 10] = new Floor(198, 10);
            TestMap.MapArray[196, 22] = new Floor(196, 22);

            TestMap.MapArray[10, 35] = new Floor(10, 35);
            TestMap.MapArray[15, 10] = new Floor(15, 10);
            TestMap.MapArray[2, 22] = new Floor(2, 22);

            TestMap.MapArray[100, 22] = new Floor(100, 22);
            TestMap.MapArray[35, 37] = new Floor(35, 37);
            TestMap.MapArray[135, 2] = new Floor(135, 2);
            TestMap.MapArray[170, 9] = new Floor(170, 9);
            TestMap.MapArray[35, 4] = new Floor(35, 4);
            watch.Reset();

            watch.Start();
            TestBrodforst.FindPath(TestMap, 1, 1);
            watch.Stop();
            
            Console.WriteLine("It took " + watch.Elapsed.Milliseconds + " ms and " + TestBrodforst.NodesVisited + " Nodes Visited for Breadth-first " +
                " Amount of nodes in final route is " + TestBrodforst.Route.Count + " nodes long");
            TestMap.MapArray[1, 1].Symbol = 'S';
            TestMap.MapArray[198, 43].Symbol = 'M';

            TestPrinter.Print2DMap(TestMap);
            TestMap.MakeEverythingFloor();
            TestMap.BuildWalls();


            TestMap.TrumpXAxis(0, 22, 198);
            TestMap.TrumpXAxis(0, 10, 198);
            TestMap.TrumpXAxis(0, 35, 198);

            TestMap.TrumpYAxis(35, 0, 44);
            TestMap.TrumpYAxis(135, 0, 44);
            TestMap.TrumpYAxis(80, 0, 44);
            TestMap.TrumpYAxis(170, 0, 44);

            TestMap.MapArray[22, 35] = new Floor(22, 35);
            TestMap.MapArray[80, 8] = new Floor(80, 8);
            TestMap.MapArray[194, 35] = new Floor(194, 35);
            TestMap.MapArray[198, 10] = new Floor(198, 10);
            TestMap.MapArray[196, 22] = new Floor(196, 22);

            TestMap.MapArray[10, 35] = new Floor(10, 35);
            TestMap.MapArray[15, 10] = new Floor(15, 10);
            TestMap.MapArray[2, 22] = new Floor(2, 22);

            TestMap.MapArray[100, 22] = new Floor(100, 22);
            TestMap.MapArray[35, 37] = new Floor(35, 37);
            TestMap.MapArray[135, 2] = new Floor(135, 2);
            TestMap.MapArray[170, 9] = new Floor(170, 9);
            TestMap.MapArray[35, 4] = new Floor(35, 4);


            watch.Reset();
            watch.Start();
            TestAstjerne.FindPath(TestMap, 1, 1);
            watch.Stop();
            Console.WriteLine("It took " + watch.Elapsed.Milliseconds + " ms and " + TestAstjerne.NodesVisited + " Nodes Visited for Astjerne" +
                " Amount of nodes in final route is " + TestAstjerne.Route.Count + " nodes long");
            TestMap.MapArray[1, 1].Symbol = 'S';
            TestMap.MapArray[198, 43].Symbol = 'M';

            TestPrinter.Print2DMap(TestMap);
            TestMap.MakeEverythingFloor();
            TestMap.BuildWalls();


            TestMap.TrumpXAxis(0, 22, 198);
            TestMap.TrumpXAxis(0, 10, 198);
            TestMap.TrumpXAxis(0, 35, 198);

            TestMap.TrumpYAxis(35, 0, 44);
            TestMap.TrumpYAxis(135, 0, 44);
            TestMap.TrumpYAxis(80, 0, 44);
            TestMap.TrumpYAxis(170, 0, 44);

            TestMap.MapArray[22, 35] = new Floor(22, 35);
            TestMap.MapArray[80, 8] = new Floor(80, 8);
            TestMap.MapArray[194, 35] = new Floor(194, 35);
            TestMap.MapArray[198, 10] = new Floor(198, 10);
            TestMap.MapArray[196, 22] = new Floor(196, 22);

            TestMap.MapArray[10, 35] = new Floor(10, 35);
            TestMap.MapArray[15, 10] = new Floor(15, 10);
            TestMap.MapArray[2, 22] = new Floor(2, 22);

            TestMap.MapArray[100, 22] = new Floor(100, 22);
            TestMap.MapArray[35, 37] = new Floor(35, 37);
            TestMap.MapArray[135, 2] = new Floor(135, 2);
            TestMap.MapArray[170, 9] = new Floor(170, 9);
            TestMap.MapArray[35, 4] = new Floor(35, 4);


            TestMap.MapArray[1, 1].Symbol = 'S';
            TestMap.MapArray[198, 43].Symbol = 'M';
            
            TestPrinter.Print2DMap(TestMap);
            /*
            Console.WriteLine("It took " + watch.Elapsed.Milliseconds + " ms and " + TestDude.NodesVisited + " Nodes Visited");
            */
            Console.ReadKey();
        }
    }
}
