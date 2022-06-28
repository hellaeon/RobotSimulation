using System;
using System.Globalization;
using System.Reflection;

namespace RobotSimulator
{
    public class Robot : ITabletopNavigator
    {
        private int _xBounds, _yBounds;
        private int _xPos, _yPos;
        private Direction _facing;

        // I could use an initializer but then I expose the bounds publicly,
        // and that means it could be changed anytime
        public Robot(int sizeX, int sizeY)
        {
            _xBounds = sizeX;
            _yBounds = sizeY;
        }

        public void ExecuteCommands(string[] commands)
        {
            foreach (string command in commands)
            {
                string currentCommand = command.ToUpper();
                if (currentCommand.Contains("PLACE"))
                    Place(currentCommand);
                else if (currentCommand.Contains("REPORT"))
                    Report();
                else if (currentCommand.Contains("MOVE"))
                    Move();
                else if (currentCommand.Contains("LEFT"))
                    Left();
                else if (currentCommand.Contains("RIGHT"))
                    Right();               
            }
        }   

        public void Place(string command)
        {
            try
            {
                var split = command.Split(" ");
                var location = split[1].Split(",");

                int X = int.Parse(location[0]);
                int Y = int.Parse(location[1]);
                Direction Facing = (Direction)Enum.Parse(typeof(Direction), location[2]);

                if (X < 0 || Y < 0 || X > _xBounds || Y > _yBounds)
                    throw new Exception("You cannot place the robot outside the bounds of the grid!");

                _xPos = X;
                _yPos = Y;
                _facing = Facing;
            }
            catch (Exception ex)
            {
                throw new Exception("invalid placement, cannot continue");
            }
        }

        public void Left()
        {
            _facing = _facing == 0 ? Direction.WEST : _facing - 1;
        }

        public void Right()
        {
            _facing = _facing == Direction.WEST ? Direction.NORTH : _facing + 1;
        }

        public void Move()
        {
            switch(_facing)
            {
                case Direction.NORTH:
                    if (_yPos + 1 > _yBounds)
                        return;
                    else _yPos++;
                    break;
                case Direction.EAST:
                    if (_xPos + 1 > _xBounds)
                        return;
                    else _xPos++;
                    break;
                case Direction.SOUTH:
                    if (_yPos - 1 < 0)
                        return;
                    else _yPos--;
                    break;
                case Direction.WEST:
                    if (_xPos - 1 < 0)
                        return;
                    else _xPos--;
                    break;
            }
        }

        public void Report()
        {
            Console.WriteLine($"{_xPos}, {_yPos} facing {_facing.ToString()}");
        }

    }
}

