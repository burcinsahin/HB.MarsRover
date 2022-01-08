using HB.MarsRover.ConsoleApp.Exceptions;
using System.Linq;

namespace HB.MarsRover.ConsoleApp
{
    public class MPlateau : BasePlateau
    {
        public MPlateau(int x, int y)
            : base(x, y) { }

        public override void Add(IRover rover)
        {
            if (Rovers.Any(r => r.Equals(rover)))
                throw new InvalidPositionException();
            base.Add(rover);
        }
    }
}