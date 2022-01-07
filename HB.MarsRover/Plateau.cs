using System;

namespace HB.MarsRover
{
    internal class Plateau
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public Plateau(int x, int y)
        {
            X = x + 1;
            Y = y + 1;
        }

        internal void Add(IRover rover)
        {
            
        }
    }
}