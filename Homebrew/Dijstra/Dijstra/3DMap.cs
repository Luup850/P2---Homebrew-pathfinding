using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijstra
{
    class ThreeDMap : Map
    {
        public int ZAmount;
        public Tile[,,] TDMapArray;
        public ThreeDMap(int x, int y, int z) : base(x,y)
        {
            ZAmount = z;
            TDMapArray = new Tile[x, y, z];
        }
    }
}
