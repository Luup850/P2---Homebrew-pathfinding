using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijstra
{
    class DiagonalMap : Map
    {


        override public void GetConnections(Tile Target)
        {

            for (int i = -1; i < 2; i++)
            {
                for (int n = -1; n < 2; n++)
                {
                    if (MapArray[Target.X + i, Target.Y + n] != null && MapArray[Target.X + i, Target.Y + n].Solid == false)
                    {
                        Target.Connections.Add(MapArray[Target.X +i, Target.Y+n ]);
                        MapArray[Target.X + i, Target.Y + n].SetStepsToGoal(GoalX, GoalY);
                    }
                }
            }

        }

        public DiagonalMap(int x, int y) : base(x, y)
        {
        }
    }

}
