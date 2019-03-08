using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijstra
{
    class HomeBrew : Player
    {
        protected List<int> Branches = new List<int>();         //List of nodes that has been visited and had more than 1 way to go
        protected int ShortestDistance = -1;
        protected int AmountOfConnections = 0;

        /// <summary>
        /// Finds a path to the goal
        /// </summary>
        /// <param name="map"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        override public void FindPath(Map map, int x, int y)
        {
            int PX;
            Route.Add(map.MapArray[x, y]);
            while (map.GoalX != x || map.GoalY != y)   //While player's position is not equal to goal. Continue
            {
                map.MapArray[x, y].Solid = true;
                map.GetConnections(map.MapArray[x, y]);  //Get all available tiles around the player and save them
                //Run through all nodes around the player
                for (int i = 0; i < map.MapArray[x, y].Connections.Count; i++)
                {
                    //Continue if the node is valid.
                    if (map.MapArray[x, y].Connections.ElementAt(i) != null && map.MapArray[x, y].Connections.ElementAt(i).Solid != true)
                    {
                        //If its the first node we are looking at. Get its distance to goal and save it as the current shortest distance
                        if (ShortestDistance == -1)
                        {
                            ShortestDistance = map.MapArray[x, y].Connections.ElementAt(i).StepsToGoal; //Save its distance to goal as the shortest distance.
                            BestOption = i; //Save the current node as best option

                        }
                        //Check if the nodes distance to the goal is shorter than the current ShortestDistance.
                        else if (ShortestDistance > map.MapArray[x, y].Connections.ElementAt(i).StepsToGoal)
                        {
                            ShortestDistance = map.MapArray[x, y].Connections.ElementAt(i).StepsToGoal; //Save its distance to goal as the shortest distance.
                            BestOption = i; //Save the current node as best option
                        }
                        AmountOfConnections++;  //Count the amount of connections for the node that the player is standing on.
                    }
                }
                //Check if the node that the player is standing has any connections
                if (AmountOfConnections != 0)
                {
                    //Check if the players current node has more than 1 connection
                    if (AmountOfConnections > 1)
                    {
                        Branches.Add(Route.Count() - 1);    //Save the players current node in case we need to backtrack.
                    }
                    Route.Add(map.MapArray[x, y].Connections.ElementAt(BestOption));    //Add the node we found to the players current route

                    ShortestDistance = -1;
                    AmountOfConnections = 0;
                    PX = x;

                    //Move the player to the node that we have determined has the shortest distance to goal.
                    x = map.MapArray[PX, y].Connections.ElementAt(BestOption).X;
                    y = map.MapArray[PX, y].Connections.ElementAt(BestOption).Y;
                }
                //The node we are standing on does not have any connected nodes we can move to.
                else
                {
                    //Go back to last place where we had the option to go more than 1 way.
                    x = Route.ElementAt(Branches.Last()).X;
                    y = Route.ElementAt(Branches.Last()).Y;

                    //We've hit a wall so we need to backtrack and remove the nodes that led to the dead end.
                    Route.RemoveRange(Branches.Last() + 1, Route.Count - Branches.Last() - 1);
                    Branches.RemoveAt(Branches.Count() - 1);
                }
                NodesVisited++;
                AmountOfConnections = 0;
            }

            //Show our route in the therminal with the letter p.
            map.MapArray[x, y].Symbol = 'm';
            for (int i = 0; i + 1 < Route.Count; i++)
            {
                Route.ElementAt(i).Symbol = 'p';
            }


        }

    }

}
