using System.Text.RegularExpressions;

namespace RobotExerciseApplication
{
    internal class Command
    {
        private static readonly Regex _placeRagexCommand = new Regex(@"PLACE (\d+),(\d+),(\w+)"); 
        private readonly Robo _robot;
        public Command(Robo robot)
        {
            _robot = robot;
        }

        internal void Execute(string command)
        {
            if (string.IsNullOrWhiteSpace(command)) return;
            if (command == "MOVE") _robot.Move();
            if (command == "LEFT") _robot.Left();
            if (command == "RIGHT") _robot.Right();
            if (command == "REPORT") _robot.Report();

            var match=_placeRagexCommand.Match(command);
            if(match.Success)
            {
                var xValid = int.TryParse(match.Groups[1].Value,out var x);
                var yValid = int.TryParse(match.Groups[2].Value, out var y);
                var direction = match.Groups[3].Value;

                if(xValid && yValid)
                {
                    _robot.Place(x, y, direction);
                }
            }
        }
    }
}
