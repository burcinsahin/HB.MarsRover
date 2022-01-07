using FluentAssertions;
using HB.MarsRover.ConsoleApp;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit;

namespace HB.MarsRover.Test
{
    public class AppTest
    {
        [Fact]
        public void Main()
        {
            var plateau = new Plateau(5, 5);
            var rover = new Rover(1, 2, 'N', plateau);
            plateau.Add(rover);
            rover.Move("LMLMLMLMM");

            rover.X.Should().Be(1);
            rover.Y.Should().Be(3);
            rover.Direction.Should().Be('N');
            rover.ToString().Should().Be("1 3 N");

            var rover2 = new Rover(3, 3, 'E', plateau);
            plateau.Add(rover2);
            rover2.Move("MMRMMRMRRM");
            rover2.ToString().Should().Be("5 1 E");
        }

        [Fact]
        public void LoadPlateau()
        {
            var input = new List<string>() { "5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM" };
            var plateau = Program.LoadPlateau(input);
            plateau.ToString().Should().Be("1 3 N\r\n5 1 E\r\n");

            input = new List<string>() { "120 120", "5 5 E", "MMMRMMMLMMM" };

        }

        [Fact]
        public void RegexMatch()
        {
            var regex1 = new Regex(@"^\d+\s+\d+$");
            regex1.IsMatch("5 5").Should().BeTrue();
            regex1.IsMatch("12 123").Should().BeTrue();

            regex1.IsMatch("").Should().BeFalse();
            regex1.IsMatch("a 4").Should().BeFalse();
            regex1.IsMatch("4").Should().BeFalse();
            regex1.IsMatch("1 3 5").Should().BeFalse();

            var regex2 = new Regex(@"^\d+\s\d+\s\w{1}$");
            regex2.IsMatch("1 3 N").Should().BeTrue();
            regex2.IsMatch("1 3  N").Should().BeFalse();
            regex2.IsMatch("1 3 NT").Should().BeFalse();

            var regex3 = new Regex(@"^\w+$");
            regex3.IsMatch("RLM").Should().BeTrue();
        }

        [Fact]
        public void StringSplit()
        {
            "3 5".Split().Length.Should().Be(2);
        }

        [Fact]
        public void MyTestMethod()
        {

        }
    }
}