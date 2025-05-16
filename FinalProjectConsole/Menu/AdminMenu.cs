using FinalProject.Helpers;

namespace FinalProject.Menu
{
    public class AdminMenu
    {
        private readonly OutputManager _outputManager;
        private InventoryMenu _inventoryMenu;
        private CharacterMenu _characterMenu;
        private RoomMenu _roomMenu;

        public AdminMenu(OutputManager outputManager, InventoryMenu inventoryMenu, CharacterMenu characterMenu, RoomMenu roomMenu)
        {
            _outputManager = outputManager;
            _inventoryMenu = inventoryMenu;
            _characterMenu = characterMenu;
            _roomMenu = roomMenu;
        }

        public void Run()
        {
            _outputManager.Clear();

            while (true)
            {
                _outputManager.WriteLine($"\n--------------------------\n", ConsoleColor.DarkMagenta);
                _outputManager.WriteLine("Welcome to the Administrator Menu!", ConsoleColor.DarkCyan);
                _outputManager.WriteLine("1. Character Management Menu");
                _outputManager.WriteLine("2. Inventory Management Menu");
                _outputManager.WriteLine("3. Room Management Menu");
                _outputManager.WriteLine("0. Quit");
                _outputManager.WriteLine($"\n--------------------------\n", ConsoleColor.DarkMagenta);
                _outputManager.Display();

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        _characterMenu.CharacterManagementMenu();
                        break;
                    case "2":
                        _inventoryMenu.InventoryManagementMenu();
                        break;
                    case "3":
                        _roomMenu.RoomManagementMenu();
                        break;
                    case "0":
                        _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                        _outputManager.WriteLine("\nExiting game...\n", ConsoleColor.Red);
                        _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                        _outputManager.Display();
                        Environment.Exit(0);
                        break;
                    default:
                        _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                        _outputManager.WriteLine("\nInvalid selection. Please choose 1, 2, or 3.\n", ConsoleColor.Red);
                        _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                        break;
                }

            }
        }
    }
}
