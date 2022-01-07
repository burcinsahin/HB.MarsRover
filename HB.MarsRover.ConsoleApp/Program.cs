using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HB.MarsRover.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var input = new List<string>();
            if (args == null || !args.Any())
                ReadInput(input);
            else
                input = args.ToList();

            var plateau = LoadPlateau(input);

            Console.WriteLine("Output:");
            Console.WriteLine(plateau);
        }

        public static Plateau LoadPlateau(List<string> input)
        {
            ValidateInput(input);

            var coords = input[0].Split().Select(int.Parse);
            var plateau = new Plateau(coords.ElementAt(0), coords.ElementAt(1));

            for (int i = 1; i <= input.Count / 2; i++)
            {
                var roverInfo = input[2 * i - 1].Split();
                var rover = new Rover(int.Parse(roverInfo[0]), int.Parse(roverInfo[1]), char.Parse(roverInfo[2]), plateau);
                plateau.Add(rover);

                rover.Move(input[2 * i]);
            }

            return plateau;
        }

        private static void ReadInput(List<string> input)
        {
            while (true)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    break;
                input.Add(line);
            }
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
