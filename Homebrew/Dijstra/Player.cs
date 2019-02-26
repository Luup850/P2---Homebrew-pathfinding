using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijstra
{
    class Player
    {
        List<Tile> Route = new List<Tile>();
        List<long> Branches = new List<long>(); 
        int BestOption;
        int ShortestDistance = -1;
        int AmountOfConnections = 0;
        public void FindPath(Map map, int x, int y)
        {
            int PX;
            Route.Add(map.MapArray[x, y]);
            Branches.Add(Route.LongCount() - 1);
            while (map.GoalX != x && map.GoalY != y )
            {
                map.MapArray[x, y].Solid = true;
                map.GetConnections(map.MapArray[x,y]);
                for(int i = 0; i < 4;i++)
                {
                    if (map.MapArray[x, y].Connections[i] != null && map.MapArray[x, y].Connections[i].Solid != true)
                    {
                        if (ShortestDistance == -1 )
                        {
                            ShortestDistance = map.MapArray[x, y].Connections[i].StepsToGoal;
                            BestOption = i;
                            
                        }
                        else if (ShortestDistance > map.MapArray[x, y].Connections[i].StepsToGoal)
                        {
                            ShortestDistance = map.MapArray[x, y].Connections[i].StepsToGoal;
                            BestOption = i;
                        }
                        AmountOfConnections++;
                    }
                }
                if (AmountOfConnections != 0)
                {
                    Route.Add(map.MapArray[x, y].Connections[BestOption]);
                    if (AmountOfConnections > 1)
                    {
                        Branches.Add(Route.LongCount() - 1);
                    }
                    ShortestDistance = -1;
                    AmountOfConnections = 0;
                    PX = x;
                    x = map.MapArray[PX, y].Connections[BestOption].X;
                    y = map.MapArray[PX, y].Connections[BestOption].Y;
                }
                else
                {
                    x = Route.ElementAt((int)Branches.Last()).X;
                    y = Route.ElementAt((int)Branches.Last()).Y;
                    Route.RemoveRange((int)Branches.Last()+1, Route.Count-(int)Branches.Last()-1);
                    Branches.RemoveAt(Branches.Count()-1);
                }
                AmountOfConnections = 0;
            }
            foreach (Tile Finish in Route)
            {
                Finish.Symbol = 'p';
            }

        }
    }
}
