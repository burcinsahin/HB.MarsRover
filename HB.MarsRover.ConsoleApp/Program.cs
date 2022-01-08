using HB.MarsRover.ConsoleApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HB.MarsRover.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var input = new List<string>();
                if (args == null || !args.Any())
                    ReadInput(input);
                else
                    input = args.ToList();

                var plateau = NasaHelper.LoadPlateau(input);

                Console.WriteLine("Output:");
                Console.WriteLine(plateau);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.GetType()}, Message:{ex.Message}");
            }
            finally
            {
                Console.WriteLine("Press any key to exit...");
                Console.Read();
            }
        }

        private static void ReadInput(List<string> input)
        {
            Console.WriteLine("Type inputs and press enter twice:");

            while (true)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                    break;
                input.Add(line);
            }
        }
    }
}
