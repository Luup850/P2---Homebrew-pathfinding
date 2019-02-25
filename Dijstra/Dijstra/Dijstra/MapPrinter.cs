using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijstra
{
    class MapPrinter
    {
        public void Print2DMap(Map map)
        {
            for (int i = 0; i < map.YAmount; i++)
            {
                for (int n = 0; n < map.XAmount; n++)
                {
                    Console.Write(map.MapArray[n, i].Symbol);

                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }
        public void Print3DMap(ThreeDMap tDMap)
        {
            string Spaces = new string(' ', tDMap.XAmount - 1);
            for (int i = 0; i < tDMap.ZAmount; i++)
            {
                Console.Write("floor " + i + Spaces);
            }
            Console.WriteLine();
            for (int k = 0; k < tDMap.YAmount; k++)
            {
                for (int i = 0; i < tDMap.ZAmount; i++)
                {
                    for (int n = 0; n < tDMap.XAmount; n++)
                    {
                        Console.Write(tDMap.TDMapArray[n, k, i].Symbol);

                    }
                    Console.Write("\t");
                }
                Console.Write("\n");
            }
        }
    }
}
