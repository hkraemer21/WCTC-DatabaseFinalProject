using FinalProjectLibrary.Models.Characters;
using FinalProjectLibrary.Models.Characters.Enemy;
using FinalProjectLibrary.Models.Characters.Players;
using FinalProjectLibrary.Models.Equipments;

namespace FinalProjectLibrary.Models.Rooms
{
    public class Room : IRoom
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Boolean IsLocked { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Enemy> Enemies { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public int? NorthId { get; set; }
        public virtual Room? North { get; set; }
        public int? SouthId { get; set; }
        public virtual Room? South { get; set; }
        public int? EastId { get; set; }
        public virtual Room? East { get; set; }
        public int? WestId { get; set; }
        public virtual Room? West { get; set; }
        public int? UpId { get; set; }
        public virtual Room? Up { get; set; }
        public int? DownId { get; set; }
        public virtual Room? Down { get; set; }

        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Players = new List<Player>();
            Enemies = new List<Enemy>();
            Items = new List<Item>();

        }

        public void GetAdjacentRooms()
        {
            Console.WriteLine($"Possible Directions:", ConsoleColor.DarkCyan);
            if (North != null)
            {
                Console.Write($"North ");
            }
            if (South != null)
            {
                Console.Write($"South ");
            }
            if (East != null)
            {
                Console.Write($"East ");
            }
            if (West != null)
            {
                Console.Write($"West ");
            }
            if (Up != null)
            {
                Console.Write($"Up ");
            }
            if (Down != null)
            {
                Console.Write($"Down ");
            }
            Console.WriteLine();
        }

        public Room GetNextRoom(string direction)
        {
            switch (direction)
            {
                case "n":
                    return North;
                case "s":
                    return South;
                case "e":
                    return East;
                case "w":
                    return West;
                case "u":
                    return Up;
                case "d":
                    return Down;
                default:
                    Console.WriteLine("Invalid direction.");
                    return null;
            }
        }

        public void GetRoomDescription(Player player)
        {
            Console.WriteLine($"{player.Name} is in {Name}. {Description}", ConsoleColor.DarkCyan);
            if (Enemies.Count != 0 && Enemies != null)
            {
                foreach (var enemy in Enemies)
                {
                    Console.WriteLine($"{enemy.Name} is here.", ConsoleColor.Red);
                }
            }
        }

        public void Enter(Player player)
        {
            if (Enemies.Count != 0 && Enemies != null)
            {
                foreach (var enemy in Enemies)
                {
                    Console.WriteLine($"{enemy.Name} is here.", ConsoleColor.Red);
                }
            }
            if (Items.Count != 0 && Items != null)
            {
                Console.Write($"{player.Name} spots: ", ConsoleColor.Green);
                foreach (var item in Items)
                {
                    Console.WriteLine($"{item.Name} ", ConsoleColor.Green);
                }
            }
        }

        public void GetEnemies()
        {
            if (Enemies.Count != 0 && Enemies != null)
            {
                foreach (var enemy in Enemies)
                {
                    Console.WriteLine($"{enemy.Name} is here.", ConsoleColor.Red);
                }
            }
            else
            {
                Console.WriteLine("There are no enemies in this room.");
            }
        }

        public void AddCharacter(ICharacter character)
        {
            if (character is Player)
            {
                Players.Add((Player)character);
            }
            else if (character is Enemy)
            {
                Enemies.Add((Enemy)character);
            }
        }

        public void RemoveCharacter(ICharacter character)
        {
            if (character is Player)
            {
                Players.Remove((Player)character);
            }
            else if (character is Enemy)
            {
                Enemies.Remove((Enemy)character);
            }
        }

        public void LootRoom(Player player)
        {
            if (this.Items != null && this.Items.Count != 0)
            {

                var items = this.Items.ToList();
                foreach (var item in items)
                {
                    bool hasNotebook = player.Inventory.Items.Any(i => i.Name == "Officer's Notebook");
                    bool alreadyHasItem = player.Inventory.Items.Any(i => i.Name == item.Name);

                    if ((item.Name == "Lion Medallion" || item.Name == "Unicorn Medallion" || item.Name == "Maiden Medallion") && !hasNotebook)
                    {
                        Console.WriteLine($"{player.Name} must find the code to unlock the {item.Name.Replace(" Medallion", " Statue")}.");
                        continue;
                    }

                    if (!alreadyHasItem)
                    {
                        Console.WriteLine($"{player.Name} found {item.Name}: {item.Description}.");
                        player.AddToInventory(item);
                        Items.Remove(item);
                    }
                    else
                    {
                        Console.WriteLine($"{player.Name} already has {item.Name} in their inventory.");
                    }
                }
            }
            else
            {
                Console.WriteLine("There is nothing to loot in this room.");
            }
        }

        public void InteractWithRoom(Player player)
        {
            if (Name == "Main Hall")
            {
                var foundLion = player.Inventory.Items.FirstOrDefault(item => item.Name == "Lion Medallion");
                var foundUnicorn = player.Inventory.Items.FirstOrDefault(item => item.Name == "Unicorn Medallion");
                var foundMaiden = player.Inventory.Items.FirstOrDefault(item => item.Name == "Maiden Medallion");

                if (foundLion != null && foundUnicorn != null && foundMaiden != null)
                {
                    Console.WriteLine($"{player.Name} places all the medallions in the base of the {Name} statue. " +
                        $"The sounds of stone scraping stone fills the {Name} as the base of the statue opens to reveal " +
                        $"a set of stairs beneath the statue.");
                    // finding the safe room
                    this.Down.IsLocked = false;
                }
                else
                {
                    Console.WriteLine($"{player.Name} does not have all the medallions. The door is locked.");
                }
            }
            else
            {
                Console.WriteLine($"{player.Name} looks around the {Name} and finds nothing to interact with.");

            }
        }


    }
}
