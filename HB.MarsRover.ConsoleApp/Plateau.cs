using System.Collections.Generic;
using System.Text;

namespace HB.MarsRover.ConsoleApp
{
    public class Plateau : IPlateau
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public List<IRover> Rovers { get; private set; }

        public Plateau(int x, int y)
        {
            X = x;
            Y = y;
            Rovers = new List<IRover>();
        }

        public void Add(IRover rover)
        {
            Rovers.Add(rover);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var rover in Rovers)
            {
                stringBuilder.AppendLine(rover.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}