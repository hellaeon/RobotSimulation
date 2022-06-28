namespace RobotSimulator
{
	public interface ITabletopNavigator
    {
        void ExecuteCommands(string[] commands);
        void Place(string command);
        void Move();
        void Left();
        void Right();
        void Report();
    }
}

