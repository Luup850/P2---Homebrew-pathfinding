using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijstra
{
    class Map
    {
        int XAmount;
        int YAmount;
        Tile[,] MapArray;

        public Map(int xAmount, int yAmount)
        {
            XAmount = xAmount;
            YAmount = yAmount;
            MapArray = new Tile[xAmount, yAmount];
        }
    }

    class Tile
    {
        bool Solid;
        int X, Y;
        int SetpsToGoal;
        protected Tile[] Connections;
        public Tile (bool solid, int x, int y)
        {
            Solid = solid;
            X = x;
            Y = y;
        }
    }
    class Wall : Tile
    {
        public Wall (int x, int y) : base(true,x,y)
        {
        }
    }

    class Player
    {

    }
}
