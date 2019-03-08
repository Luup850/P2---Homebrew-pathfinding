using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijstra
{
    class Player
    {
        public List<Tile> Route = new List<Tile>();
        protected List<int> Branches = new List<int>(); 
        protected int BestOption;
        protected int ShortestDistance = -1;
        protected int AmountOfConnections = 0;
        public int NodesVisited = 0;
        virtual public void FindPath(Map map, int x, int y)
        {
            int PX;
            Route.Add(map.MapArray[x, y]);
            while (map.GoalX != x || map.GoalY != y )
            {
                map.MapArray[x, y].Solid = true;
                map.GetConnections(map.MapArray[x,y]);
                for(int i = 0; i < map.MapArray[x, y].Connections.Count; i++)
                {
                    if (map.MapArray[x, y].Connections.ElementAt(i) != null && map.MapArray[x, y].Connections.ElementAt(i).Solid != true)
                    {
                        if (ShortestDistance == -1 )
                        {
                            ShortestDistance = map.MapArray[x, y].Connections.ElementAt(i).StepsToGoal;
                            BestOption = i;
                            
                        }
                        else if (ShortestDistance > map.MapArray[x, y].Connections.ElementAt(i).StepsToGoal)
                        {
                            ShortestDistance = map.MapArray[x, y].Connections.ElementAt(i).StepsToGoal;
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
                    Route.Add(map.MapArray[x, y].Connections.ElementAt(BestOption));

                    ShortestDistance = -1;
                    AmountOfConnections = 0;
                    PX = x;
                    x = map.MapArray[PX, y].Connections.ElementAt(BestOption).X;
                    y = map.MapArray[PX, y].Connections.ElementAt(BestOption).Y;
                }
                else
                {

                    x = Route.ElementAt(Branches.Last()).X;
                    y = Route.ElementAt(Branches.Last()).Y;
                    Route.RemoveRange(Branches.Last()+1, Route.Count-Branches.Last()-1);

                    Branches.RemoveAt(Branches.Count()-1);
                }
                NodesVisited++;
                AmountOfConnections = 0;
            }
            map.MapArray[x, y].Symbol = 'm';
            for (int i = 0; i+1 < Route.Count; i++)
            {
                Route.ElementAt(i).Symbol = 'p';
            }
            

        }
        public Player ()
        {
        }
    } 

}
