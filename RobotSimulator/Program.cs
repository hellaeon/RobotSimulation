using RobotSimulator;

public class RobotSimulation
{
	public static void Main()
	{
		// load in the text commands from a file
		CommandReader commandReader = new CommandReader();
		string[] commands = commandReader.GetValidCommandsFromFile();

		// pass a list to my robot simulator class and execute it.
		Robot robot = new Robot(5,5);
		robot.ExecuteCommands(commands);
	}
}