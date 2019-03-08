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
        /// <summary>
        /// Finds a path to the goal
        /// </summary>
        /// <param name="map"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        override public void FindPath(Map map, int x, int y)
        {
            int AwayFromstart = 0;
            map.MapArray[x, y].StepsFromStart = 0;
            map.MapArray[x, y].Visited = true;
            //Continue while player's position is not equal to goal.
            while (map.GoalX != x || map.GoalY != y)    
            {

                map.GetConnections(map.MapArray[x, y]);//Get connections from the node that the algorithm is on.
                for (int i = 0; i < map.MapArray[x, y].Connections.Count; i++)
                {
                    //Checks if the node has not been scanned.
                    if ( map.MapArray[x, y].Connections.ElementAt(i).Visited != true)
                    {
                        // Adds node to queue of unvisited nodes
                        SearchArea.Enqueue(map.MapArray[x, y].Connections[i]);
                        
                        map.MapArray[x, y].Connections.ElementAt(i).Visited = true; // Set node as scanned
                        map.MapArray[x, y].Connections.ElementAt(i).StepsFromStart = AwayFromstart + 1;
                    }
                }

                NextTile = SearchArea.Dequeue(); // Gets next node in queue and begins again from that node
                x = NextTile.X;
                y = NextTile.Y;
                //Route.Add(map.MapArray[x, y]); //Debug statement to show full scan area
                NodesVisited++;
                AwayFromstart = NextTile.StepsFromStart;
            }
            //We've found the goal and has a list of all potential interesting nodes

            
            map.MapArray[x, y].Symbol = 'm';
            Route.Add(map.MapArray[x, y]);
            //Start at goal and continue while distance from start is not 0.
            while (AwayFromstart != 0) {
                map.GetConnections(map.MapArray[x, y]); //Get connections from the node that the algorithm is on.
                //Loop through all connections
                for (int i = 0; i < map.MapArray[x, y].Connections.Count; i++)
                {
                    //If the node has been scanned, then its a possible route back.
                    if ( map.MapArray[x, y].Connections.ElementAt(i).Visited == true)
                    {
                        //Find the node with the shortest distance from start, compared to the other connected nodes.
                        if (map.MapArray[x, y].Connections.ElementAt(i).StepsFromStart < AwayFromstart)
                        {
                            Route.Add(map.MapArray[x, y].Connections.ElementAt(i));
                            AwayFromstart = map.MapArray[x, y].Connections.ElementAt(i).StepsFromStart; //Set AwayFromstart to current since it is the shortest distance atm.
                            NextTile = map.MapArray[x, y].Connections.ElementAt(i);
                            // move position to next tile
                            x = NextTile.X; 
                            y = NextTile.Y;
                            
                        }
                    }
                }
            }
            //Set the route that has been found, nodes symbol to P so it can be printed.
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
