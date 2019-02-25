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

        void GetConnections(Tile Target)
        {

        }
    }

    abstract class Tile
    {
        bool Solid;
        int X, Y;
        int SetpsToGoal;
        string Symbol;
        public Tile[] Connections = new Tile[4];
        public Tile (bool solid, int x, int y, string symbol)
        {
            Solid = solid;
            X = x;
            Y = y;
            Symbol = symbol;
        }
    }
    class Wall : Tile
    {
        public Wall (int x, int y, string _symbol) : base(true, x, y, _symbol)
        {
        }
    }

    class Player
    {
        List<Tile> Route = new List<Tile>();
        
    }
}
