using FinalProject.Helpers;
using FinalProjectLibrary.Data;
using FinalProjectLibrary.Models.Characters.Players;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Menu
{
    public class CharacterMenu
    {
        private readonly GameContext _context;
        private readonly OutputManager _outputManager;
        public CharacterMenu(GameContext context, OutputManager outputManager)
        {
            _context = context;
            _outputManager = outputManager;
        }

        public void CharacterManagementMenu()
        {
            _outputManager.Clear();
            _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Magenta);
            _outputManager.WriteLine("Welcome to the Character Menu!", ConsoleColor.Cyan);
            _outputManager.WriteLine("1. Display all characters");
            _outputManager.WriteLine("2. Add new character");
            _outputManager.WriteLine("3. Remove existing character");
            _outputManager.WriteLine("4. Edit existing character");
            _outputManager.WriteLine("5. Search character by name");
            _outputManager.WriteLine("6. Display character abilities");
            _outputManager.WriteLine("7. Add ability to character");
            _outputManager.WriteLine("8. Remove ability from character");
            _outputManager.WriteLine("0. Back to Main Menu");
            _outputManager.WriteLine($"\n--------------------------\n", ConsoleColor.Magenta);


            _outputManager.Display();

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    DisplayCharacters();
                    break;
                case "2":
                    AddCharacter();
                    break;
                case "3":
                    RemoveCharacter();
                    break;
                case "4":
                    EditCharacter();
                    break;
                case "5":
                    SearchCharacter();
                    break;
                case "6":
                    DisplayAbilities();
                    break;
                case "7":
                    AddAbility();
                    break;
                case "8":
                    RemoveAbility();
                    break;
                case "0":
                    _outputManager.WriteLine($"\n--------------------------", ConsoleColor.DarkCyan);
                    _outputManager.WriteLine("\nReturning to main menu...\n", ConsoleColor.DarkCyan);
                    _outputManager.WriteLine($"--------------------------\n", ConsoleColor.DarkCyan);
                    _outputManager.Display();
                    break;
                default:
                    _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                    _outputManager.WriteLine("\nInvalid selection. Please choose 1.\n", ConsoleColor.Red);
                    _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                    break;

            }
        }


        private void DisplayCharacters()
        {
            _outputManager.WriteLine("Displaying all characters:", ConsoleColor.Cyan);
            _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Magenta);

            var players = _context.Players.ToList();

            foreach (var player in players)
            {
                _outputManager.WriteLine($"ID: {player.Id}\nName: {player.Name}\nHealth: {player.Health}");
                _outputManager.WriteLine($"\n--------------------------\n", ConsoleColor.Magenta);
            }
            _outputManager.Display();
        }

        private void AddCharacter()
        {
            _outputManager.WriteLine("Adding a new character:", ConsoleColor.Cyan);
            _outputManager.WriteLine($"--------------------------", ConsoleColor.Magenta);
            _outputManager.Write("Enter character name: ");
            _outputManager.Display();

            var name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("\nInvalid input. Please try again.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                return;
            }

            _outputManager.Write("Enter character health: ");
            _outputManager.Display();

            var health = Console.ReadLine();
            if (string.IsNullOrEmpty(health))
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("\nInvalid input. Please try again.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                return;
            }

            if (!int.TryParse(health, out int healthValue) || healthValue <= 0)
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("\nInvalid health value. Please try again.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                return;
            }

            if (string.IsNullOrEmpty(name) || healthValue <= 0)
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("\nInvalid input. Please try again.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                return;
            }

            if (_context.Players.Any(p => p.Name.ToLower() == name.ToLower()))
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine($"\nCharacter with name {name} already exists.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                return;
            }

            var newPlayer = new Player(name, healthValue);
            _context.Players.Add(newPlayer);
            _context.SaveChanges();

            _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Green);
            _outputManager.WriteLine($"\n{name} added successfully!\n", ConsoleColor.Green);
            _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Green);
            _outputManager.Display();
        }

        private void RemoveCharacter()
        {
            _outputManager.WriteLine("Removing a character:", ConsoleColor.Cyan);
            _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Magenta);
            _outputManager.Display();

            var playerName = _context.Players.ToList();
            foreach (var n in playerName)
            {
                _outputManager.WriteLine($"ID: {n.Id}\nName: {n.Name}");
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Magenta);
            }

            _outputManager.Write("Enter character ID to remove: ");
            _outputManager.Display();

            var id = Console.ReadLine();
            if (string.IsNullOrEmpty(id) || !int.TryParse(id, out int idValue))
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("\nInvalid input. Please try again.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                return;
            }

            var player = _context.Players.Find(idValue);
            if (player == null)
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine($"\nCharacter with ID {id} not found.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                return;
            }

            if (player.Inventory != null)
            {
                _context.Remove(player.Inventory);
            }

            _context.Players.Remove(player);
            _context.SaveChanges();

            _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Green);
            _outputManager.WriteLine($"\n{player.Name} removed successfully!\n", ConsoleColor.Green);
            _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Green);
            _outputManager.Display();
        }

        private void EditCharacter()
        {
            _outputManager.WriteLine("Editing a character:", ConsoleColor.Cyan);
            _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Magenta);
            _outputManager.Display();

            var playerName = _context.Players.ToList();
            foreach (var n in playerName)
            {
                _outputManager.WriteLine($"ID: {n.Id}\nName: {n.Name}");
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Magenta);
            }

            _outputManager.Write("Enter character ID to edit: ");
            _outputManager.Display();

            var id = Console.ReadLine();
            if (string.IsNullOrEmpty(id) || !int.TryParse(id, out int idValue))
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("\nInvalid input. Please try again.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                return;
            }

            var player = _context.Players.Find(idValue);
            if (player == null)
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine($"\nCharacter with ID {id} not found.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                return;
            }

            _outputManager.Write("Enter new character name: ");
            _outputManager.Display();

            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("\nInvalid input. Please try again.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                return;
            }

            _outputManager.Write("Enter new character health: ");
            _outputManager.Display();

            var health = Console.ReadLine();
            if (string.IsNullOrEmpty(health) || !int.TryParse(health, out int healthValue) || healthValue <= 0)
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("\nInvalid health value. Please try again.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                return;
            }

            player.Name = name;
            player.Health = healthValue;
            _context.SaveChanges();

            _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Green);
            _outputManager.WriteLine($"\n{name} updated successfully!\n", ConsoleColor.Green);
            _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Green);
            _outputManager.Display();
        }

        private void SearchCharacter()
        {
            _outputManager.WriteLine("Searching for a character:", ConsoleColor.Cyan);
            _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Magenta);
            _outputManager.Write("Enter character's full name to search: ");
            _outputManager.Display();

            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("\nInvalid input. Please try again.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                return;
            }

            var player = _context.Players.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
            if (player == null)
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine($"\nCharacter with name {name} not found.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                return;
            }

            _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Green);
            _outputManager.WriteLine($"\nCharacter found:\nID: {player.Id}\nName: {player.Name}" +
                $"\nHealth: {player.Health}\n", ConsoleColor.Green);
            _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Green);
            _outputManager.Display();
        }

        private void DisplayAbilities()
        {
            _outputManager.WriteLine("Display a character's abilities:", ConsoleColor.Cyan);
            _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Magenta);
            _outputManager.Display();

            var players = _context.Players.ToList();
            foreach (var p in players)
            {
                _outputManager.WriteLine($"ID: {p.Id}\nName: {p.Name}");
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Magenta);
            }

            _outputManager.WriteLine("Enter the ID of the character:", ConsoleColor.Cyan);
            _outputManager.Display();

            var id = Console.ReadLine();
            if (string.IsNullOrEmpty(id) || !int.TryParse(id, out int idValue))
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("\nInvalid input. Please try again.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                return;
            }

            var player = _context.Players.Include(p => p.PlayerAbilities).FirstOrDefault(p => p.Id == idValue);
            if (player == null)
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine($"\nCharacter with ID {id} not found.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                return;
            }

            if (player.PlayerAbilities.Count == 0)
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine($"\n{player.Name} has no abilities.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                return;
            }

            _outputManager.WriteLine($"\n--------------------------\n", ConsoleColor.Magenta);
            _outputManager.WriteLine($"\nAbilities of {player.Name}:\n", ConsoleColor.Green);

            foreach (var ability in player.PlayerAbilities)
            {
                _outputManager.WriteLine($"ID: {ability.Id}\nName: {ability.Name}\nDescription: {ability.Description}" +
                    $"\nDamage: {ability.Damage}", ConsoleColor.DarkCyan);
                _outputManager.WriteLine($"\n--------------------------\n", ConsoleColor.Magenta);

            }

            _outputManager.Display();

        }

        private void AddAbility()
        {
            _outputManager.WriteLine("Adding an ability to a character:", ConsoleColor.Cyan);
            _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Magenta);
            _outputManager.Display();

            var players = _context.Players.ToList();
            foreach (var p in players)
            {
                _outputManager.WriteLine($"ID: {p.Id}\nName: {p.Name}");
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Magenta);
            }

            _outputManager.Write("Enter character ID to add ability: ");
            _outputManager.Display();

            var id = Console.ReadLine();
            if (string.IsNullOrEmpty(id) || !int.TryParse(id, out int idValue))
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("\nInvalid input. Please try again.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                return;
            }

            var player = _context.Players.Include(p => p.PlayerAbilities).FirstOrDefault(p => p.Id == idValue);
            if (player != null)
            {

                var abilities = _context.PlayerAbilities.ToList();
                foreach (var ability in abilities)
                {
                    _outputManager.WriteLine($"\nID: {ability.Id}\nName: {ability.Name}");
                    _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Magenta);
                }

                _outputManager.Write("Enter ability ID to add: ");
                _outputManager.Display();

                var abilityId = Console.ReadLine();
                if (string.IsNullOrEmpty(abilityId) || !int.TryParse(abilityId, out int abilityIdValue))
                {
                    _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                    _outputManager.WriteLine("\nInvalid input. Please try again.\n", ConsoleColor.Red);
                    _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                    return;
                }

                var abilityToAdd = _context.PlayerAbilities.Find(abilityIdValue);
                if (abilityToAdd == null)
                {
                    _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                    _outputManager.WriteLine($"\nAbility with ID {abilityId} not found.\n", ConsoleColor.Red);
                    _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                    return;
                }

                if (player.PlayerAbilities.Contains(abilityToAdd))
                {
                    _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                    _outputManager.WriteLine($"\n{player.Name} already has {abilityToAdd.Name} ability.\n", ConsoleColor.Red);
                    _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                    return;
                }

                player.PlayerAbilities.Add(abilityToAdd);
                _context.SaveChanges();

                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Green);
                _outputManager.WriteLine($"\n{abilityToAdd.Name} added to {player.Name} successfully!\n", ConsoleColor.Green);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Green);
            }
            else
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine($"\nCharacter with ID {id} not found.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);

            }
            _outputManager.Display();

        }

        public void RemoveAbility()
        {
            _outputManager.WriteLine("Removing an ability from a character:", ConsoleColor.Cyan);
            _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Magenta);
            _outputManager.Display();

            var players = _context.Players.ToList();
            foreach (var p in players)
            {
                _outputManager.WriteLine($"ID: {p.Id}\nName: {p.Name}");
                var abilitys = p.PlayerAbilities.ToList();
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Magenta);
            }

            _outputManager.Write("Enter character ID to remove ability: ");
            _outputManager.Display();

            var id = Console.ReadLine();
            if (string.IsNullOrEmpty(id) || !int.TryParse(id, out int idValue))

            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine("\nInvalid input. Please try again.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                return;
            }

            var player = _context.Players.Include(p => p.PlayerAbilities).FirstOrDefault(p => p.Id == idValue);
            if (player != null)
            {
                var abilities = player.PlayerAbilities.ToList();
                foreach (var ability in abilities)
                {
                    _outputManager.WriteLine($"\nID: {ability.Id}\nName: {ability.Name}");
                    _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Magenta);
                }

                _outputManager.Write("Enter ability ID to remove: ");
                _outputManager.Display();

                var abilityId = Console.ReadLine();

                if (string.IsNullOrEmpty(abilityId) || !int.TryParse(abilityId, out int abilityIdValue))
                {
                    _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                    _outputManager.WriteLine("\nInvalid input. Please try again.\n", ConsoleColor.Red);
                    _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                    return;
                }

                var abilityToRemove = player.PlayerAbilities.FirstOrDefault(a => a.Id == abilityIdValue);

                if (abilityToRemove == null)
                {
                    _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                    _outputManager.WriteLine($"\nAbility with ID {abilityId} not found.\n", ConsoleColor.Red);
                    _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                    return;

                }
                if (!player.PlayerAbilities.Contains(abilityToRemove))
                {
                    _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                    _outputManager.WriteLine($"\n{player.Name} does not have {abilityToRemove.Name} ability.\n", ConsoleColor.Red);
                    _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
                    return;
                }

                player.PlayerAbilities.Remove(abilityToRemove);
                _context.SaveChanges();
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Green);
                _outputManager.WriteLine($"\n{abilityToRemove.Name} removed from {player.Name} successfully!\n", ConsoleColor.Green);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Green);

            }
            else
            {
                _outputManager.WriteLine($"\n--------------------------", ConsoleColor.Red);
                _outputManager.WriteLine($"\nCharacter with ID {id} not found.\n", ConsoleColor.Red);
                _outputManager.WriteLine($"--------------------------\n", ConsoleColor.Red);
            }

            _outputManager.Display();

        }
    }
}