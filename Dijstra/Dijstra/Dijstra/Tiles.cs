using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijstra
{
    abstract class Tile
    {
        public bool Solid;
        public int X, Y;
        public int StepsToGoal;
        public char Symbol;
        public Tile[] Connections = new Tile[4];
        public Tile(bool solid, int x, int y, char symbol)
        {
            Solid = solid;
            X = x;
            Y = y;
            Symbol = symbol;
        }
        public void SetStepsToGoal(int gX, int gY)
        {
            gX -= X;
            gY -= Y;
            if (gX < 0)
            {
                gX *= -1;
            }
            if (gY < 0)
            {
                gY *= -1;
            }
            StepsToGoal = gX + gY;
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
        public Floor(int x, int y) : base(false,x,y,'.')
        {
        }
    }
}
