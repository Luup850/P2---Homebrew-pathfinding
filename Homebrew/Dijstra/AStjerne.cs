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
                for (int i = 0; i < map.MapArray[x, y].Connections.Count; i++)
                {
                    if (map.MapArray[x, y].Connections.ElementAt(i).Visited != true)
                    {

                        Open.Add(map.MapArray[x, y].Connections[i]);
                        

                        map.MapArray[x, y].Connections.ElementAt(i).Visited = true;
                        map.MapArray[x, y].Connections.ElementAt(i).StepsFromStart = AwayFromstart + 1;
                        map.MapArray[x, y].Connections.ElementAt(i).CalcTotalCost();
                    }
                }
                for(int i = 0; i < Open.Count; i++)
                {

                
                    if (Open.ElementAt(i).TotalCost < BestCost || counter == 0)
                    {
                        BestCost = Open.ElementAt(i).TotalCost;
                        BestOption = counter;
                    }
                    counter++;
                }
                //Route.Add(Open.ElementAt(BestOption)); // Debug statement, shows all tiles searched
                NodesVisited++;
                NextTile = Open.ElementAt(BestOption);
                Open.RemoveAt(BestOption);
                counter = 0;
                BestOption = 0;
                x = NextTile.X;
                y = NextTile.Y;
                AwayFromstart = NextTile.StepsFromStart;


            }
            Route.Add(map.MapArray[x, y]);
            map.MapArray[x, y].Symbol = 'm';
            while (AwayFromstart != 0)
            {
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
            for(int i = 0; i < Route.Count;i++) 
            {
                Route.ElementAt(i).Symbol = 'p';
            }
        }

        public AStjerne () : base()
        {
        }
    }
}
