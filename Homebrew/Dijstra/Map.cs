using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijstra
{
    class Map
    {
        public int XAmount;
        public int YAmount;
        public  Tile[,] MapArray;
        public int GoalX;
        public int GoalY;

        public Map(int xAmount, int yAmount)
        {
            XAmount = xAmount;
            YAmount = yAmount;
            MapArray = new Tile[xAmount, yAmount];
        }
        public void SetGoal(int x, int y)
        {
            GoalX = x;
            GoalY = y;
        } 

         virtual public void GetConnections(Tile Target)
        {
            if(MapArray[Target.X, Target.Y+1 ].Solid == false && MapArray[Target.X, Target.Y + 1] != null)
            {
                Target.Connections.Add(MapArray[Target.X, Target.Y + 1]);
                MapArray[Target.X, Target.Y + 1].SetStepsToGoal(GoalX,GoalY);
            }
            if (MapArray[Target.X, Target.Y-1 ].Solid == false && MapArray[Target.X, Target.Y - 1] != null)
            {
                Target.Connections.Add(MapArray[Target.X, Target.Y - 1] );
                MapArray[Target.X, Target.Y - 1].SetStepsToGoal(GoalX, GoalY);
            }
            if (MapArray[Target.X+1, Target.Y].Solid == false && MapArray[Target.X+1, Target.Y] != null)
            {
                Target.Connections.Add(MapArray[Target.X + 1, Target.Y]);
                MapArray[Target.X+1, Target.Y].SetStepsToGoal(GoalX, GoalY);
            }
            if (MapArray[Target.X-1, Target.Y].Solid == false && MapArray[Target.X, Target.Y - 1] != null)
            {
                Target.Connections.Add(MapArray[Target.X - 1, Target.Y]);
                MapArray[Target.X-1, Target.Y].SetStepsToGoal(GoalX, GoalY);
            }
        }
        public void MakeEverythingFloor()
        {
            for(int i = 0; i < XAmount; i++)
            {
                for(int n = 0; n < YAmount; n++)
                {
                    MapArray[i, n] = new Floor(i, n);
                }
            }
        }
        public void BuildWalls ()
        {
            for(int i = 0; i < XAmount; i++)
            {
                MapArray[i, 0] = new Wall(i,0);
                MapArray[i, YAmount-1] = new Wall(i, YAmount-1);
            }
            for (int i = 0; i < YAmount; i++)
            {
                MapArray[0, i] = new Wall(0, i);
                MapArray[XAmount-1, i] = new Wall(XAmount-1, i);
            }
        }
        public void TrumpXAxis (int x, int y, int FinishX )
        {
            for(int i = x; i <= FinishX;i++)
            {
                MapArray[i, y] = new Wall(i, y);
            }
        }
        public void TrumpYAxis(int x, int y, int FinishY)
        {
            for (int i = y; i <= FinishY; i++)
            {
                MapArray[x, i] = new Wall(x, i);
            }
        }
    }



}
