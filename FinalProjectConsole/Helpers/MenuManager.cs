using FinalProject.Helpers;

namespace ConsoleRpg.Helpers;

public class MenuManager
{
    private readonly OutputManager _outputManager;

    public MenuManager(OutputManager outputManager)
    {
        _outputManager = outputManager;
    }

    public bool ShowMainMenu()
    {
        _outputManager.WriteLine("Welcome to the Raccoon City Police Station!", ConsoleColor.Yellow);
        _outputManager.WriteLine("1. Start Game", ConsoleColor.Cyan);
        _outputManager.WriteLine("3. Exit", ConsoleColor.Cyan);
        _outputManager.Display();

        return HandleMainMenuInput();
    }

    private bool HandleMainMenuInput()
    {
        while (true)
        {
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Green);
                    _outputManager.WriteLine("\nStarting game...\n", ConsoleColor.Green);
                    _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Green);
                    _outputManager.Display();
                    Thread.Sleep(500);
                    return true;
                case "2":
                    _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                    _outputManager.WriteLine("\nExiting game...\n", ConsoleColor.Red);
                    _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                    _outputManager.Display();
                    Thread.Sleep(500);
                    Environment.Exit(0);
                    return false;
                default:
                    _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                    _outputManager.WriteLine("\nInvalid selection. Please choose 1 or 2.\n", ConsoleColor.Red);
                    _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                    _outputManager.Display();
                    break;
            }
        }
    }
}
