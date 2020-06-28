using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class MarsRoverCaseService
    {
        static void Main(string[] args)
        {
            RoverOperation("1 2 N", "LMLMLMLMM");
            RoverOperation("3 3 E", "MMRMMRMRRM");

            Console.ReadKey();
        }

        public static string RoverOperation(string RoverPositionStr, string RoverMovements)
        {
            RoverPositionStr = RoverPositionStr.Trim();
            RoverMovements = RoverMovements.Trim();
            Rover rover = RoverPositionParse(RoverPositionStr);
            foreach (char MovementCommand in RoverMovements.ToCharArray())
                if (MovementCommand == 'M')
                    switch (rover.Direction)
                    {
                        case 'N': rover.Y++; break;
                        case 'W': rover.X--; break;
                        case 'S': rover.Y--; break;
                        case 'E': rover.X++; break;
                    }
                else
                    rover.Direction =
                        MovementResults.FirstOrDefault(
                            lookup => lookup.MovementCommand == MovementCommand && lookup.RoverPosition == rover.Direction
                            ).NewRoverPosition;

            Console.WriteLine("Input Position : {0}", RoverPositionStr);
            Console.WriteLine("Input MoveList : {0}", RoverMovements);
            Console.WriteLine("Output = {0} {1} {2}", rover.X, rover.Y, rover.Direction);
            Console.WriteLine("");
            return rover.X + " " + rover.Y + " " + rover.Direction;
        }

        private static Rover RoverPositionParse(string RoverPositionStr)
        {
            return new Rover() { X = Convert.ToInt32(RoverPositionStr.Split(' ')[0]), Y = Convert.ToInt32(RoverPositionStr.Split(' ')[1]), Direction = Convert.ToChar(RoverPositionStr.Split(' ')[2]) };
        }

        private static readonly List<(char MovementCommand, char RoverPosition, char NewRoverPosition)> MovementResults = new List<(char MovementCommand, char RoverPosition, char NewRoverPosition)>
        {
            ('L', 'N', 'W'),
            ('L', 'W', 'S'),
            ('L', 'S', 'E'),
            ('L', 'E', 'N'),
            ('R', 'N', 'E'),
            ('R', 'W', 'N'),
            ('R', 'S', 'W'),
            ('R', 'E', 'S')
        };

        private  class Rover
        {
            public int X { get; set; }
            public int Y { get; set; }
            public char Direction { get; set; }
        }
    }
}
