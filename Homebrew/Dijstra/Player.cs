using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijstra
{
    class Player
    {
        protected List<Tile> Route = new List<Tile>();
        protected List<int> Branches = new List<int>(); 
        protected int BestOption;
        protected int ShortestDistance = -1;
        protected int AmountOfConnections = 0;
        protected int MaxConnections;
        public int NodesVisited = 0;
        virtual public void FindPath(Map map, int x, int y)
        {
            int PX;
            Route.Add(map.MapArray[x, y]);
            while (map.GoalX != x || map.GoalY != y )
            {
                map.MapArray[x, y].Solid = true;
                map.GetConnections(map.MapArray[x,y]);
                for(int i = 0; i < MaxConnections;i++)
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
                    if (AmountOfConnections > 1)
                    {
                        Branches.Add(Route.Count() - 1);
                    }
                    Route.Add(map.MapArray[x, y].Connections[BestOption]);

                    ShortestDistance = -1;
                    AmountOfConnections = 0;
                    PX = x;
                    x = map.MapArray[PX, y].Connections[BestOption].X;
                    y = map.MapArray[PX, y].Connections[BestOption].Y;
                }
                else
                {

                    x = Route.ElementAt(Branches.Last()).X;
                    y = Route.ElementAt(Branches.Last()).Y;
                    Route.RemoveRange(Branches.Last()+1, Route.Count-Branches.Last()-1);

                    Branches.RemoveAt(Branches.Count()-1);
                }
                AmountOfConnections = 0;
            }
            foreach (Tile Finish in Route)
            {
                Finish.Symbol = 'p';
            }

        }
        public Player (int maxConnections)
        {
            MaxConnections = maxConnections;
        }
    } 

}
