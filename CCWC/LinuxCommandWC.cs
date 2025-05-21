namespace CCWC;

public static class LinuxCommandWC
{
    private const string NoSuchCommand = "no such command";
    private const string baseFilePath = "C:\\Users\\Sam\\RiderProjects\\CCWC\\";
    private static string useCommand { get; set; }
    private static string useFileName { get; set; }
    
    public static void Command(string command)
    {
       if (ValidCommand(command))
       {
           RunCommand();
       }
       else
       {
           Console.WriteLine(NoSuchCommand);
       }
    }

    private static void RunCommand()
    {
        if (useCommand.Equals("-c"))
        {
            Byte[] fileBytes = File.ReadAllBytes(baseFilePath + useFileName);
            Console.WriteLine(fileBytes.Length);
        }
        StreamReader reader = new StreamReader(baseFilePath + useFileName);
        
        
    }

    private static bool ValidCommand(string command)
    {
        string [] splitCommand  = command.Trim().Split(" ");
        string commandName = splitCommand[0];
        string fileName = splitCommand[1];

        if (commandName != null && commandName.ToLower().Equals("-c") && fileName.ToLower().Equals("test.txt"))
        {
            useCommand = commandName.ToLower();
            useFileName = fileName;
            return true;
        }
        
        return false;
    }
}