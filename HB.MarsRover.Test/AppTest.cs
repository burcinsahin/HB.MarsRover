using FluentAssertions;
using HB.MarsRover.ConsoleApp;
using HB.MarsRover.ConsoleApp.Exceptions;
using HB.MarsRover.ConsoleApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit;
using Xunit.Abstractions;

namespace HB.MarsRover.Test
{
    public class AppTest
    {
        private readonly ITestOutputHelper _outputHelper;

        public AppTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        private void WriteLine(string format, params string[] args)
        {
            _outputHelper.WriteLine(format, args);
        }

        [Fact]
        public void Main()
        {
            var plateau = new MPlateau(5, 5);
            var rover = new MRover(plateau, 1, 2, 'N');
            plateau.Add(rover);
            rover.Move("LMLMLMLMM");

            rover.X.Should().Be(1);
            rover.Y.Should().Be(3);
            rover.Direction.Should().Be('N');
            rover.ToString().Should().Be("1 3 N");

            var rover2 = new MRover(plateau, 3, 3, 'E');
            plateau.Add(rover2);
            rover2.Move("MMRMMRMRRM");
            rover2.ToString().Should().Be("5 1 E");
        }

        [Fact]
        public void LoadPlateau()
        {
            var input = new List<string>() { "5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM" };
            var plateau = NasaHelper.LoadPlateau(input);
            plateau.ToString().Should().Be("1 3 N\r\n5 1 E\r\n");

            input = new List<string>() { "10 10", "5 5 E", "MMMRMMMLMMMRMMM" };
            plateau = NasaHelper.LoadPlateau(input);
            plateau.ToString().Should().Be("10 0 S\r\n");

            input = new List<string>() { "10 10", "5 5 E", "", "5 4 N", "M", "4 4 N", "RM" };
            plateau = NasaHelper.LoadPlateau(input);
            plateau.ToString().Should().Be("5 5 E\r\n5 4 N\r\n4 4 E\r\n");
        }

        [Fact]
        public void InvalidPosition()
        {
            Action action = () =>
            {
                var input = new List<string>() { "10 10", "11 5 N", "MMMRMMMLMMMRMMM" };
                var plateau = NasaHelper.LoadPlateau(input);
            };
            action.Should().ThrowExactly<InvalidPositionException>();

            Action action2 = () =>
            {
                var input = new List<string>() { "10 10", "1 1 N", "M", "1 2 N", "M" };
                var plateau = NasaHelper.LoadPlateau(input);
            };
            action2.Should().ThrowExactly<InvalidPositionException>();
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

            var regex3 = new Regex(@"^\w*$");
            regex3.IsMatch("RLMGSD").Should().BeTrue();
            regex3.IsMatch("").Should().BeTrue();
            regex3.IsMatch("RLM asda").Should().BeFalse();
        }

        [Fact]
        public void StringSplit()
        {
            "3 5".Split().Length.Should().Be(2);
        }
    }
}