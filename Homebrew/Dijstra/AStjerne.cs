using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijstra
{
    class AStjerne : Player
    {
        int BestCost;
        List<Tile> Open = new List<Tile>();
        int counter = 0;
        Tile NextTile;

        override public void FindPath(Map map, int x, int y)
        {
            int AwayFromstart = 0;
            map.MapArray[x, y].StepsFromStart = 0;
            map.MapArray[x, y].Visited = true;
            while (map.GoalX != x || map.GoalY != y)
            {
                map.GetConnections(map.MapArray[x, y]);
                for (int i = 0; i < MaxConnections; i++)
                {
                    if (map.MapArray[x, y].Connections[i] != null && map.MapArray[x, y].Connections[i].Solid != true
                        && map.MapArray[x, y].Connections[i].Visited != true)
                    {

                        Open.Add(map.MapArray[x, y].Connections[i]);
                        

                        map.MapArray[x, y].Connections[i].Visited = true;
                        map.MapArray[x, y].Connections[i].StepsFromStart = AwayFromstart + 1;
                        map.MapArray[x, y].Connections[i].CalcTotalCost();
                    }
                }
                foreach (Tile tile in Open)
                {
                    if (tile.TotalCost < BestCost || counter == 0)
                    {
                        BestCost = tile.TotalCost;
                        BestOption = counter;
                    }
                    counter++;
                }
                Route.Add(Open.ElementAt(BestOption));
                NodesVisited++;
                NextTile = Open.ElementAt(BestOption);
                Open.RemoveAt(BestOption);
                counter = 0;
                BestOption = 0;
                x = NextTile.X;
                y = NextTile.Y;
                AwayFromstart = NextTile.StepsFromStart;


            }
            map.MapArray[x, y].Symbol = 'm';
            while (AwayFromstart != 0)
            {
                map.GetConnections(map.MapArray[x, y]);
                for (int i = 0; i < MaxConnections; i++)
                {
                    if (map.MapArray[x, y].Connections[i] != null && map.MapArray[x, y].Connections[i].Visited == true)
                    {
                        if (map.MapArray[x, y].Connections[i].StepsFromStart < AwayFromstart)
                        {
                            Route.Add(map.MapArray[x, y].Connections[i]);
                            AwayFromstart = map.MapArray[x, y].Connections[i].StepsFromStart;
                            NextTile = map.MapArray[x, y].Connections[i];
                            x = NextTile.X;
                            y = NextTile.Y;
                        }
                    }
                }
            }
            foreach (Tile Finish in Route)
            {
                Finish.Symbol = 'p';
            }
        }

        public AStjerne (int maxConnections) : base(maxConnections)
        {
        }
    }
}
