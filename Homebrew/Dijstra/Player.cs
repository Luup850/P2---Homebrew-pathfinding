using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijstra
{
    abstract class Player
    {
        public List<Tile> Route = new List<Tile>();             //List of nodes that has been visited
        protected int BestOption;
        public int NodesVisited = 0;

        /// <summary>
        /// Finds a path to the goal
        /// </summary>
        /// <param name="map"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        virtual public void FindPath(Map map, int x, int y)
        {

        }

        public Player()
        {
        }
    }
}
