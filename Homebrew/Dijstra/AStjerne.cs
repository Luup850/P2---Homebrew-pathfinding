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

        /// <summary>
        /// Finds a path to the goal
        /// </summary>
        /// <param name="map">Map that the player needs to search</param>
        /// <param name="x">X start position</param>
        /// <param name="y">Y start position</param>
        override public void FindPath(Map map, int x, int y)
        {
            int AwayFromstart = 0;
            map.MapArray[x, y].StepsFromStart = 0;
            map.MapArray[x, y].Visited = true;

            //Continue while player's position is not equal to goal.
            while (map.GoalX != x || map.GoalY != y)
            {
                map.GetConnections(map.MapArray[x, y]); //Get connections from the node that the algorithm is on.
                
                //Run through all the nodes around the current node the algorithm is looking at.
                for (int i = 0; i < map.MapArray[x, y].Connections.Count; i++)
                {
                    //Checks if the node has not been scanned.
                    if (map.MapArray[x, y].Connections.ElementAt(i).Visited != true)
                    {

                        Open.Add(map.MapArray[x, y].Connections[i]);    //Add to list of potential nodes that can be visited.
                        

                        map.MapArray[x, y].Connections.ElementAt(i).Visited = true; //Node has been scanned
                        map.MapArray[x, y].Connections.ElementAt(i).StepsFromStart = AwayFromstart + 1;
                        map.MapArray[x, y].Connections.ElementAt(i).CalcTotalCost();
                    }
                }

                //Check which node is the best in terms of cost.
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

            //We've found the goal and has a list of all potential interesting nodes

            //Start at goal and continue while distance from start is not 0.
            while (AwayFromstart != 0)
            {
                map.GetConnections(map.MapArray[x, y]);

                //Loop through all connections
                for (int i = 0; i < map.MapArray[x, y].Connections.Count; i++)
                {
                    //If the node has been scanned, then its a possible route back.
                    if ( map.MapArray[x, y].Connections.ElementAt(i).Visited == true)
                    {
                        //Check 
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
