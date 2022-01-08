using HB.MarsRover.ConsoleApp.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HB.MarsRover.ConsoleApp.Helpers
{
    public class NasaHelper
    {
        /// <summary>
        /// Loads the plateau with rovers from a batch of inputs
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static IPlateau LoadPlateau(List<string> input)
        {
            ValidateInput(input);

            var coords = input[0].Split().Select(int.Parse);
            var plateau = new MPlateau(coords.ElementAt(0), coords.ElementAt(1));

            for (int i = 1; i <= input.Count / 2; i++)
            {
                var roverInfo = input[2 * i - 1].Split();
                var rover = new MRover(plateau, int.Parse(roverInfo[0]), int.Parse(roverInfo[1]), char.Parse(roverInfo[2]));
                plateau.Add(rover);

                rover.Move(input[2 * i]);
            }

            return plateau;
        }

        private static void ValidateInput(List<string> input)
        {
            if (!input.Any()) throw new InvalidInputException();

            var regex1 = new Regex(@"^\d+\s+\d+$");
            if (!regex1.IsMatch(input[0]))
                throw new InvalidInputException();

            if (input.Count <= 1)
                return;

            if (input.Count.IsEven())
                throw new InvalidInputException();

            var regex2 = new Regex(@"^\d+\s\d+\s\w{1}$");
            var regex3 = new Regex(@"^\w+$");

            for (int i = 1; i < input.Count; i++)
            {
                if (i.IsOdd() && !regex2.IsMatch(input[i]))
                    throw new InvalidInputException();
                else if (i.IsEven() && !regex3.IsMatch(input[i]))
                    throw new InvalidInputException();
            }
        }
    }
}