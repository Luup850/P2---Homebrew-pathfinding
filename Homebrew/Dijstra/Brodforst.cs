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
                for (int i = 0; i < map.MapArray[x, y].Connections.Count; i++)
                {
                    if ( map.MapArray[x, y].Connections.ElementAt(i).Visited != true)
                    {
                        SearchArea.Enqueue(map.MapArray[x, y].Connections[i]);
                        
                        map.MapArray[x, y].Connections.ElementAt(i).Visited = true;
                        map.MapArray[x, y].Connections.ElementAt(i).StepsFromStart = AwayFromstart + 1;
                    }
                }

                NextTile = SearchArea.Dequeue();
                x = NextTile.X;
                y = NextTile.Y;
                //Route.Add(map.MapArray[x, y]); //Debug statement to show full scan area
                NodesVisited++;
                AwayFromstart = NextTile.StepsFromStart;
            }
            
            map.MapArray[x, y].Symbol = 'm';
            Route.Add(map.MapArray[x, y]);
            while (AwayFromstart != 0) {
                map.GetConnections(map.MapArray[x, y]);
                for (int i = 0; i < map.MapArray[x, y].Connections.Count; i++)
                {
                    if ( map.MapArray[x, y].Connections.ElementAt(i).Visited == true)
                    {
                        if (map.MapArray[x, y].Connections.ElementAt(i).StepsFromStart < AwayFromstart)
                        {
                            Route.Add(map.MapArray[x, y].Connections.ElementAt(i));
                            AwayFromstart = map.MapArray[x, y].Connections.ElementAt(i).StepsFromStart;
                            NextTile = map.MapArray[x, y].Connections.ElementAt(i);
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

        public Brodforst() : base()
        {
        }
    }
}
