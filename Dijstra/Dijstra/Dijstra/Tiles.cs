using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijstra
{ 
    abstract class Tile
    {
        bool Solid;
        int X, Y;
        int SetpsToGoal;
        public char Symbol;
        public Tile[] Connections = new Tile[4];
        public Tile(bool solid, int x, int y, char symbol)
        {
            Solid = solid;
            X = x;
            Y = y;
            Symbol = symbol;
        }
    }
    class Wall : Tile
    {
        public Wall(int x, int y) : base(true, x, y, 'w')
        {
        }
    }
    class Floor : Tile
    {
        public Floor(int x, int y) : base(false,x,y,'f')
        {
        }
    }
}
