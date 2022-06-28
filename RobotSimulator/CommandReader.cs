using System.IO;

namespace RobotSimulator
{
    public class CommandReader : ITabletopCommandService
    {
        int _commandsStartIndex;

        public string[] GetValidCommandsFromFile(string fileName = "./commands.txt")
        {
            string commandsPath = Path.Combine(Environment.CurrentDirectory, @$"{fileName}");
            string[] commands = File.ReadAllLines(commandsPath);

            _commandsStartIndex = -1;
            for (int x = 0; x < commands.Length; x++)
            {
                if (commands[x].Contains("PLACE"))
                {
                    _commandsStartIndex = x;
                    break;
                }
            }

            // was there any valid place commands?
            if (_commandsStartIndex < 0)
                throw new Exception("No initial place command");

            // return from the initial place command, ignore previous guff
            return commands[_commandsStartIndex..commands.Length];
        }
    }
}

