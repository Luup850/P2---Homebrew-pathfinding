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

        public Map(int xAmount, int yAmount)
        {
            XAmount = xAmount;
            YAmount = yAmount;
            MapArray = new Tile[xAmount, yAmount];
        }

        void GetConnections(Tile Target)
        {
            if(MapArray[Target.X, Target.Y+1 ].Solid == true)
            {
                Target.Connections[0] = MapArray[Target.X, Target.Y + 1];
            }
            if (MapArray[Target.X, Target.Y-1 ].Solid == true)
            {
                Target.Connections[1] = MapArray[Target.X, Target.Y - 1];
            }
            if (MapArray[Target.X+1, Target.Y].Solid == true)
            {
                Target.Connections[2] = MapArray[Target.X + 1, Target.Y];
            }
            if (MapArray[Target.X-1, Target.Y].Solid == true)
            {
                Target.Connections[3] = MapArray[Target.X - 1, Target.Y];
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
            for(int i = 0; i < YAmount; i++)
            {
                MapArray[i, 0] = new Wall(i,0);
                MapArray[i, YAmount-1] = new Wall(i, YAmount-1);
            }
            for (int i = 0; i < XAmount; i++)
            {
                MapArray[0, i] = new Wall(0, i);
                MapArray[XAmount-1, i] = new Wall(XAmount-1, i);
            }
        }
    }



}
