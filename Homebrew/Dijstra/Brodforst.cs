using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijstra
{
    class Brodforst : Player
    {
        Queue<Tile> SearchArea = new Queue<Tile>();
        Tile NextTile;

        override public void FindPath(Map map, int x, int y)
        {
            int AwayFromstart = 0;
            map.MapArray[x, y].StepsFromStart = 0;
            map.MapArray[x, y].Visited = true;
            while (map.GoalX != x || map.GoalY != y)
            {

                map.GetConnections(map.MapArray[x, y]);
                for (int i = 0; i < MaxConnections;i++)
                {
                    if (map.MapArray[x, y].Connections[i] != null && map.MapArray[x, y].Connections[i].Solid != true
                        && map.MapArray[x, y].Connections[i].Visited != true)
                    {
                        SearchArea.Enqueue(map.MapArray[x, y].Connections[i]);
                        
                        map.MapArray[x, y].Connections[i].Visited = true;
                        map.MapArray[x, y].Connections[i].StepsFromStart = AwayFromstart + 1;
                    }
                }

                NextTile = SearchArea.Dequeue();
                x = NextTile.X;
                y = NextTile.Y;
                AwayFromstart = NextTile.StepsFromStart;
            }
            map.MapArray[x, y].Symbol = 'm';
            while (AwayFromstart != 0) {
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

        public Brodforst(int maxConnections) : base(maxConnections)
        {
        }
    }
}
