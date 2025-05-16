using FinalProject.Helpers;
using FinalProjectLibrary.Data;
using FinalProjectLibrary.Models.Rooms;

namespace FinalProject.Menu
{
    public class RoomMenu
    {
        private readonly GameContext _context;
        private readonly OutputManager _outputManager;
        public RoomMenu(GameContext context, OutputManager outputManager)
        {
            _context = context;
            _outputManager = outputManager;
        }

        public void RoomManagementMenu()
        {
            _outputManager.Clear();
            _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Magenta);
            _outputManager.WriteLine("Welcome to the Room Menu!", ConsoleColor.Cyan);
            _outputManager.WriteLine("1. Display all rooms");
            _outputManager.WriteLine("2. Add new room");
            _outputManager.WriteLine("3. List characters in room by attribute");
            _outputManager.WriteLine("0. Back to Main Menu");
            _outputManager.WriteLine($"\n--------------------------\n", ConsoleColor.Magenta);


            _outputManager.Display();

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    DisplayRooms();
                    break;
                case "2":
                    AddRoom();
                    break;
                case "3":
                    ListByAttribute();
                    break;
                case "0":
                    _outputManager.WriteLine("\nReturning to main menu...", ConsoleColor.Green);
                    _outputManager.Display();
                    break;
                default:
                    _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                    _outputManager.WriteLine("\nInvalid selection. Please choose 1.\n", ConsoleColor.Red);
                    _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                    _outputManager.Display();
                    break;

            }
        }

        private void DisplayRooms()
        {
            var rooms = _context.Rooms.ToList();
            if (rooms.Count == 0)
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Yellow);
                _outputManager.WriteLine("No rooms available.", ConsoleColor.Yellow);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Yellow);
                _outputManager.Display();
            }

            else
            {
                foreach (var room in rooms)
                {

                    _outputManager.WriteLine($"Room ID: {room.Id}\nName: {room.Name}\nDescription: {room.Description}", ConsoleColor.Cyan);
                    _outputManager.WriteLine($"\nItems:", ConsoleColor.DarkCyan);

                    foreach (var item in room.Items)
                    {
                        _outputManager.WriteLine($"{item.Name}", ConsoleColor.DarkYellow);
                    }
                    _outputManager.WriteLine($"\nCharacters:", ConsoleColor.DarkCyan);

                    foreach (var player in room.Players)
                    {
                        _outputManager.WriteLine($"Character: {player.Name}", ConsoleColor.Green);
                    }

                    foreach (var enemy in room.Enemies)
                    {
                        _outputManager.WriteLine($"Enemy: {enemy.Name}", ConsoleColor.Red);
                    }

                    _outputManager.WriteLine($"\n--------------------------\n", ConsoleColor.Magenta);
                }
            }
            _outputManager.Display();
        }

        private void AddRoom()
        {
            _outputManager.WriteLine("Enter room name:", ConsoleColor.Cyan);
            _outputManager.Display();

            var name = Console.ReadLine();
            if (name == null)
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("Room name cannot be empty.", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                _outputManager.Display();
                return;
            }

            _outputManager.WriteLine("Enter room description:", ConsoleColor.Cyan);
            _outputManager.Display();

            var description = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("Room description cannot be empty.", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                _outputManager.Display();
                return;
            }

            var newRoom = new Room(name, description);
            _context.Rooms.Add(newRoom);
            _context.SaveChanges();

            _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Green);
            _outputManager.WriteLine($"Room '{name}' added successfully!", ConsoleColor.Green);
            _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Green);
            _outputManager.Display();

        }
        private void ListByAttribute()
        {

            var rooms = _context.Rooms.ToList();
            if (rooms.Count == 0)
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Yellow);
                _outputManager.WriteLine("No rooms available.", ConsoleColor.Yellow);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Yellow);
                _outputManager.Display();
                return;
            }

            foreach ( var r in rooms) {
                _outputManager.WriteLine($"Room ID: {r.Id}\nName: {r.Name}", ConsoleColor.Cyan);
                _outputManager.WriteLine($"\n--------------------------\n", ConsoleColor.Magenta);
            }

            _outputManager.WriteLine("Enter the room ID:", ConsoleColor.Cyan);
            _outputManager.Display();
            var roomIdInput = Console.ReadLine();
            if (!int.TryParse(roomIdInput, out int roomId))
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("Invalid room ID.", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                _outputManager.Display();
                return;
            }
            var room = _context.Rooms.FirstOrDefault(r => r.Id == roomId);
            if (room == null)
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("Room not found.", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                _outputManager.Display();
                return;
            }

            _outputManager.WriteLine("Enter the attribute to filter by (Name/AttackPower/Health):", ConsoleColor.Cyan);
            _outputManager.Display();

            var attribute = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(attribute))
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("Attribute cannot be empty.", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                _outputManager.Display();
                return;
            }

            _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Magenta);
            _outputManager.WriteLine($"Characters in room {room.Name} with attribute {attribute}:", ConsoleColor.Cyan);
            _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Magenta);
            _outputManager.Display();

            if (attribute.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                foreach (var player in room.Players)
                {
                    _outputManager.WriteLine($"Character: {player.Name}", ConsoleColor.Green);
                }
                foreach (var enemy in room.Enemies)
                {
                    _outputManager.WriteLine($"Enemy: {enemy.Name}", ConsoleColor.Red);
                }
            }
            else if (attribute.Equals("AttackPower", StringComparison.OrdinalIgnoreCase))
            {
                foreach (var enemy in room.Enemies)
                {
                    _outputManager.WriteLine($"Enemy: {enemy.Name}, Attack Power: {enemy.AttackPower}", ConsoleColor.Red);
                }
            }
            else if (attribute.Equals("Health", StringComparison.OrdinalIgnoreCase))
            {
                foreach (var player in room.Players)
                {
                    _outputManager.WriteLine($"Character: {player.Name}, Health: {player.Health}", ConsoleColor.Green);
                }
                foreach (var enemy in room.Enemies)
                {
                    _outputManager.WriteLine($"Enemy: {enemy.Name}, Health: {enemy.Health}", ConsoleColor.Red);
                }
            }
            else
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("Invalid attribute.", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
            }



        }














    }
}