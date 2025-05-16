using FinalProject.Helpers;
using FinalProjectLibrary.Data;
using FinalProjectLibrary.Models.Equipments;
using FinalProjectLibrary.Models.Equipments.Items;

namespace FinalProject.Menu
{
    public class InventoryMenu
    {
        private readonly GameContext _context;
        private readonly OutputManager _outputManager;
        public InventoryMenu(GameContext context, OutputManager outputManager)
        {
            _context = context;
            _outputManager = outputManager;
        }

        public void InventoryManagementMenu()
        {
            _outputManager.Clear();
            _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Magenta);
            _outputManager.WriteLine("Welcome to the Inventory Menu!", ConsoleColor.Cyan);
            _outputManager.WriteLine("1. Display all items");
            _outputManager.WriteLine("2. Search for item by name");
            _outputManager.WriteLine("3. List items by type");
            _outputManager.WriteLine("4. Sort items");
            _outputManager.WriteLine("0. Back to Main Menu");
            _outputManager.WriteLine($"\n--------------------------\n", ConsoleColor.Magenta);

            _outputManager.Display();

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    DisplayAllItems();
                    break;
                case "2":
                    SearchByName();
                    break;
                case "3":
                    ListByType();
                    break;
                case "4":
                    SortSubmenu();
                    break;
                case "0":
                    _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Green);
                    _outputManager.WriteLine("\nReturning to main menu...\n", ConsoleColor.Green);
                    _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Green);
                    _outputManager.Display();
                    break;
                default:
                    _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                    _outputManager.WriteLine("\nInvalid selection. Please choose 1.\n", ConsoleColor.Red);
                    _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                    break;
            }
        }

        private void SortSubmenu()
        {
            _outputManager.Clear();
            _outputManager.WriteLine($"\n--------------------------\n", ConsoleColor.Magenta);
            _outputManager.WriteLine("Sort Options", ConsoleColor.Cyan);
            _outputManager.WriteLine("1. Sort by Name");
            _outputManager.WriteLine("2. Sort by Damage Value");
            _outputManager.WriteLine("3. Sort by Healing Value");
            _outputManager.WriteLine("4. Sort by Used or Not");
            _outputManager.WriteLine("0. Back to Main Menu");
            _outputManager.WriteLine($"\n--------------------------\n", ConsoleColor.Magenta);

            _outputManager.Display();

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    SortByName();
                    break;
                case "2":
                    SortByDamage();
                    break;
                case "3":
                    SortByHealing();
                    break;
                case "4":
                    SortByWasUsed();
                    break;
                case "0":
                    _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Green);
                    _outputManager.WriteLine("\nReturning to main menu...\n", ConsoleColor.Green);
                    _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Green);
                    _outputManager.Display();
                    break;
                default:
                    _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                    _outputManager.WriteLine("\nInvalid selection. Please choose 1.\n", ConsoleColor.Red);
                    _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                    break;
            }
        }

        public void DisplayAllItems()
        {
            _outputManager.WriteLine($"--------------------------", ConsoleColor.Magenta);

            var items = _context.Items.ToList();
            foreach (var item in items)
            {
                ListItems(item);
            }
        }

        private void ListItems(Item item)
        {
            switch (item.Type)
            {
                case "Weapon":

                    if (item is Weapon weapon)
                    {
                        _outputManager.WriteLine($"\nID: {weapon.Id}");
                        _outputManager.Write($"Type: ");
                        _outputManager.WriteLine($"{weapon.Type}", ConsoleColor.Red);
                        _outputManager.WriteLine($"Name: {weapon.Name}\nDescription: {weapon.Description}" +
                            $"\nDamage: {weapon.Damage}");

                        if (weapon.DamageOverTime > 0)
                        {
                            _outputManager.WriteLine($"Damage Over Time: {weapon.DamageOverTime}");
                        }

                        if (weapon.RoomId != null)
                        {
                            var room = _context.Rooms.FirstOrDefault(r => r.Id == weapon.RoomId);
                            if (room != null)
                            {
                                _outputManager.WriteLine($"Location (Room): {room.Name}\n");
                            }
                            else
                            {
                                _outputManager.WriteLine($"Location (Room): Unknown (ID: {weapon.RoomId}\n)");
                            }
                        }

                        else if (weapon.InventoryId != null)
                        {
                            var player = _context.Players.FirstOrDefault(p => p.Id == weapon.InventoryId);
                            if (player != null)
                            {

                                var room = _context.Rooms.FirstOrDefault(r => r.Id == player.RoomId);
                                if (room != null)
                                {
                                    _outputManager.WriteLine($"Location (Player): {player.Name} (Room: {room.Name})\n");
                                }
                                else
                                {
                                    _outputManager.WriteLine($"Location (Player): {player.Name} (Room: Unknown)\n");
                                }

                            }
                            else
                            {
                                _outputManager.WriteLine($"Location (Player): Unknown (ID: {weapon.InventoryId}\n)");
                            }

                        }
                        else
                        {
                            _outputManager.WriteLine($"Location: None\n");
                        }

                    }
                    _outputManager.WriteLine($"--------------------------", ConsoleColor.Magenta);
                    break;

                case "FirstAid":

                    if (item is FirstAid aid)
                    {

                        _outputManager.Write($"\nType: ");
                        _outputManager.WriteLine($"{aid.Type}", ConsoleColor.Green);
                        _outputManager.WriteLine($"Name: {aid.Name}\nDescription: {aid.Description}" +
                            $"\nHealing: {aid.Healing}");

                        if (aid.RoomId != null)
                        {

                            var room = _context.Rooms.FirstOrDefault(r => r.Id == aid.RoomId);
                            if (room != null)
                            {
                                _outputManager.WriteLine($"Location (Room): {room.Name}\n");
                            }
                            else
                            {
                                _outputManager.WriteLine($"Location (Room): Unknown (ID: {aid.RoomId}\n)");
                            }

                        }
                        else if (aid.InventoryId != null)
                        {

                            var player = _context.Players.FirstOrDefault(p => p.Id == aid.InventoryId);
                            if (player != null)
                            {

                                var room = _context.Rooms.FirstOrDefault(r => r.Id == player.RoomId);
                                if (room != null)
                                {
                                    _outputManager.WriteLine($"Location (Player): {player.Name} (Room: {room.Name})\n");
                                }
                                else
                                {
                                    _outputManager.WriteLine($"Location (Player): {player.Name} (Room: Unknown)\n");
                                }

                            }
                            else
                            {
                                _outputManager.WriteLine($"Location (Player): Unknown (ID: {aid.InventoryId}\n)");
                            }
                        }
                        else
                        {
                            _outputManager.WriteLine($"Location: None\n");
                        }
                    }

                    _outputManager.WriteLine($"--------------------------", ConsoleColor.Magenta);
                    break;

                case "KeyItem":

                    if (item is KeyItem key)
                    {

                        _outputManager.Write($"\nType: ");
                        _outputManager.WriteLine($"{key.Type}", ConsoleColor.DarkYellow);
                        _outputManager.WriteLine($"Name: {key.Name}\nDescription: {key.Description}");

                        if (key.WasUsed == true)
                        {
                            _outputManager.WriteLine($"Was Used: Yes");
                        }
                        else
                        {
                            _outputManager.WriteLine($"Was Used: No");
                        }

                        if (key.RoomId != null)
                        {

                            var room = _context.Rooms.FirstOrDefault(r => r.Id == key.RoomId);
                            if (room != null)
                            {
                                _outputManager.WriteLine($"Location (Room): {room.Name}\n");
                            }
                            else
                            {
                                _outputManager.WriteLine($"Location (Room): Unknown (ID: {key.RoomId})\n");
                            }

                        }
                        else if (key.InventoryId != null)
                        {

                            var player = _context.Players.FirstOrDefault(p => p.Id == key.InventoryId);
                            if (player != null)
                            {

                                var room = _context.Rooms.FirstOrDefault(r => r.Id == player.RoomId);
                                if (room != null)
                                {
                                    _outputManager.WriteLine($"Location (Player): {player.Name} (Room: {room.Name})\n");
                                }
                                else
                                {
                                    _outputManager.WriteLine($"Location (Player): {player.Name} (Room: Unknown)\n");
                                }

                            }
                            else
                            {
                                _outputManager.WriteLine($"Location (Player): Unknown (ID: {key.InventoryId})\n");
                            }

                        }
                        else
                        {
                            _outputManager.WriteLine($"Location: None\n");
                        }
                    }

                    _outputManager.WriteLine($"--------------------------", ConsoleColor.Magenta);
                    break;

                default:

                    _outputManager.WriteLine("Unknown item type.\n", ConsoleColor.Red);
                    _outputManager.WriteLine($"--------------------------", ConsoleColor.Magenta);
                    break;
            }
        }

        private void SearchByName()
        {

            var name = _context.Items.ToList();
            foreach (var n in name)
            {
                _outputManager.WriteLine($"{n.Name}");
            }

            _outputManager.Write("Enter the name of the item to search for: ", ConsoleColor.Cyan);
            _outputManager.Display();

            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("\nInvalid input. Please try again.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                _outputManager.Display();
                return;
            }

            var item = _context.Items.FirstOrDefault(i => i.Name.ToLower().Equals(input));
            _outputManager.WriteLine($"--------------------------", ConsoleColor.Magenta);
            if (item != null)
            {
                ListItems(item);
            }
            else
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("\nItem not found.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                _outputManager.Display();
            }

        }

        private void ListByType()
        {
            _outputManager.WriteLine("Enter the type of item to list (Weapon/FirstAid/KeyItem):", ConsoleColor.Cyan);
            _outputManager.Display();

            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("Invalid input. Please try again.", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                _outputManager.Display();
                return;
            }

            var items = _context.Items.Where(i => i.Type.ToLower().Equals(input)).ToList();
            if (items.Any())
            {

                _outputManager.WriteLine($"--------------------------", ConsoleColor.Magenta);
                foreach (var item in items)
                {
                    ListItems(item);
                }

            }
            else
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("No items found of that type.", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                _outputManager.Display();
            }

        }

        private void SortByName()
        {

            _outputManager.WriteLine($"--------------------------", ConsoleColor.Magenta);

            var items = _context.Items.OrderBy(i => i.Name).ToList();
            foreach (var item in items)
            {
                ListItems(item);
            }

        }

        private void SortByDamage()
        {

            _outputManager.WriteLine($"--------------------------", ConsoleColor.Magenta);

            var items = _context.Items.OfType<Weapon>().OrderBy(i => i.Damage).ToList();
            foreach (var item in items)
            {
                ListItems(item);
            }

        }

        private void SortByHealing()
        {

            _outputManager.WriteLine($"--------------------------", ConsoleColor.Magenta);

            var items = _context.Items.OfType<FirstAid>().OrderBy(i => i.Healing).ToList();
            foreach (var item in items)
            {
                ListItems(item);
            }

        }

        private void SortByWasUsed()
        {

            _outputManager.WriteLine($"--------------------------", ConsoleColor.Magenta);

            var items = _context.Items.OfType<KeyItem>().OrderBy(i => i.WasUsed).ToList();
            foreach (var item in items)
            {
                ListItems(item);
            }

        }
    }
}
