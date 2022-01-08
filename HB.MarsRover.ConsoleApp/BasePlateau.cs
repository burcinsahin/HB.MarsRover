using System.Collections.Generic;
using System.Text;

namespace HB.MarsRover.ConsoleApp
{
    public abstract class BasePlateau : IPlateau
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public List<IRover> Rovers { get; protected set; }

        protected BasePlateau(int x, int y)
        {
            X = x;
            Y = y;
            Rovers = new List<IRover>();
        }

        public virtual void Add(IRover rover)
        {
            Rovers.Add(rover);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var rover in Rovers)
            {
                stringBuilder.AppendLine(rover.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}