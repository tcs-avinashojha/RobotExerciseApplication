using RobotExerciseApplication;

public class Program
{
    public static void Main(string[] args)
    {
        // read input files from launch settings command line argument
        var userInput = args.Where(File.Exists);
        foreach (var input in userInput)
        {
            Console.WriteLine("Executing command from: " + input);
            Console.WriteLine();

            ProcessCommand(input);

            Console.WriteLine();
            Console.WriteLine("---------------------------------");
            Console.WriteLine();
        }

        Console.ReadLine();
    }

    // Process input request for robo movement. 
    private static void ProcessCommand(string input)
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
