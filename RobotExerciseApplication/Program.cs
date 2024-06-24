using RobotExerciseApplication;

public class Program
{
    public static void Main(string[] args)
    {
        var userInput = args.Where(File.Exists);
        foreach (var input in userInput)
        {
            Console.WriteLine("Executing command from: " + input);
            Console.WriteLine();

            ExecuteCommand(input);

            Console.WriteLine();
            Console.WriteLine("---------------------------------");
            Console.WriteLine();
        }

        Console.ReadLine();
    }

    private static void ExecuteCommand(string input)
    {
        var robot = new Robo();
        var roboCommand = new Command(robot);

        using (var file = new StreamReader(input))
        {
            string command;
            while ((command = file.ReadLine()) != null)
            {
                Console.WriteLine("Executing command: " + command);
                roboCommand.Execute(command);
            }
        }
    }
}
