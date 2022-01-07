using System;
using System.Text;

namespace HB.MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var plateau = new Plateau(5,5);
            var rover = new Rover(1, 2, 'N');
            rover.Move("LMLMLMLMM");
            var rover2 = new Rover(3, 3, 'E');
            rover2.Move("MMRMMRMRRM");

        }
    }
}
