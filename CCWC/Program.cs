// See https://aka.ms/new-console-template for more information

using CCWC;

bool running = true;

Console.WriteLine("type exit to exit");
while (running)
{
    string input = Console.ReadLine();
    LinuxCommandWC.Command(input);
    if (input != null && input.ToLower().Equals("exit"))
    {
        running = false;
    }
}

