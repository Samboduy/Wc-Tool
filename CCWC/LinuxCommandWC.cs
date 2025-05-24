namespace CCWC;

public static class LinuxCommandWC
{
    private const string NoSuchCommand = "could not execute command";
    private static string path {get; set;}
    private static string useCommand { get; set; }
    private static string useFileName { get; set; }
    
    public static void Command(string command)
    {
       if (ValidCommand(command))
       {
           FindPath();
           try
           {
               RunCommand();
           }
           catch (Exception e)
           {
               Console.WriteLine("could not find path");
               Console.WriteLine();
           }
           
       }
       else
       {
           Console.WriteLine(NoSuchCommand);
       }
    }

    private static void FindPath()
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);

        while (dir != null && !dir.GetFiles("*.sln").Any())
        {
            dir = dir.Parent;
        }

        if (dir?.FullName == null)
        {
            throw new Exception("Could not locate solution root.");
        }
        else
        {
            path = Path.Combine(dir.FullName,useFileName);
        }
    }

    private static void RunCommand()
    {
        string result;
        switch (useCommand)
        {
            case "-c":
                result = NumberOfBytesCommand();
                WriteResult(result);
                break;
            case "-l":
                result = NumberOfLinesCommand();
                WriteResult(result);
                break;
                
        }
        
    }

    private static string NumberOfBytesCommand()
    {
        return File.ReadAllBytes(path).Length.ToString();
    }

    private static string NumberOfLinesCommand()
    {
        return File.ReadLines(path).Count().ToString();
    }

    private static void WriteResult(string result)
    {
        Console.WriteLine(result + " " + useFileName);
    }

    private static bool ValidCommand(string command)
    {
        string [] splitCommand  = command.Trim().Split(" ");
        if (splitCommand.Length > 1)
        {
            string? commandName = splitCommand[0].ToLower();
            string fileName = splitCommand[1].ToLower();
            switch (commandName)
            {
                case "-c":
                    SetCommandAndFileName(commandName, fileName);
                    return true;
                case "-l":
                    SetCommandAndFileName(commandName, fileName);
                    return true;
            }
        }
        else if (splitCommand[0] != "")
        {
            return false;
        }
        return false;
    }

    private static void SetCommandAndFileName(string command,string fileName)
    {
        useCommand = command;
        useFileName = fileName;
    }
}