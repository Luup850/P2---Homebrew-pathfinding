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
            int PX;
            Route.Add(map.MapArray[x, y]);
            while (map.GoalX != x || map.GoalY != y)
            {

                map.MapArray[x, y].Solid = true;
                map.GetConnections(map.MapArray[x, y]);
                for (int i = 0; i < MaxConnections;i++)
                {
                    if (map.MapArray[x, y].Connections[i] != null && map.MapArray[x, y].Connections[i].Solid != true)
                    {
                        SearchArea.Enqueue(map.MapArray[x, y].Connections[i]);
                        
                        map.MapArray[x, y].Connections[i].Solid = true;
                    }
                }

                NextTile = SearchArea.Dequeue();
                PX = x;
                x = NextTile.X;
                y = NextTile.Y;
                Route.Add(map.MapArray[x, y]);
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
