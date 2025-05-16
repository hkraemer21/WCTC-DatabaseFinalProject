using FinalProjectLibrary.Models.Abilities.PlayerAbilities;
using FinalProjectLibrary.Models.Attributes;
using FinalProjectLibrary.Models.Equipments;
using FinalProjectLibrary.Models.Equipments.Items;
using FinalProjectLibrary.Models.Rooms;

namespace FinalProjectLibrary.Models.Characters.Players
{
    public class Player : ICharacter, ITargetable
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int? RoomId { get; set; }
        public virtual Room Room { get; set; }
        public virtual Inventory? Inventory { get; set; }
        public int? EquippedId { get; set; }
        public virtual Weapon Equipped { get; set; }
        public virtual ICollection<PlayerAbility> PlayerAbilities { get; set; }

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
            PlayerAbilities = new List<PlayerAbility>();
            Inventory = new Inventory() { Player = this };
        }


        public void Attack(ITargetable target)
        {
            Console.WriteLine($"{Name} takes aim and shoots {target.Name} with {Equipped}.", ConsoleColor.Green);
            target.TakeDamage(Equipped.Damage);

        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"Remaining health: {Health}");
            if (Health <= 0)
            {
                Console.WriteLine($"{Name} has been defeated!", ConsoleColor.Red);
                Console.WriteLine("Game Over!", ConsoleColor.Red);
                Environment.Exit(0);
            }
        }

        public void UseAbility(PlayerAbility ability, ITargetable target)
        {
            if (PlayerAbilities.Contains(ability))
            {
                ability.UseAbility(this, target);
            }
            else
            {
                Console.WriteLine($"{Name} does not have {ability.Name} ability.");
            }
        }

        public void EquipWeapon(Weapon weapon)
        {
            if (Inventory.Items.Contains(weapon))
            {
                Equipped = weapon;
                Console.WriteLine($"{Name} has equipped {weapon.Name}.");
            }
            else
            {
                Console.WriteLine($"{Name} does not have {weapon.Name} in their inventory.");
            }
        }

        public void AddToInventory(Item item)
        {
            if (Inventory == null)
            {
                Inventory = new Inventory();
            }
            Inventory.Items.Add(item);
            Console.WriteLine($"{item.Name} has been added to {Name}'s inventory.");
        }

        public void RemoveFromInventory(Item item)
        {
            if (Inventory != null && Inventory.Items.Contains(item))
            {
                Inventory.Items.Remove(item);
                Console.WriteLine($"{item.Name} was removed from {Name}'s inventory.");
            }
            else
            {
                Console.WriteLine($"{item.Name} is not in {Name}'s inventory.");
            }
        }

        public void DisplayInventory()
        {
            if (Inventory != null && Inventory.Items.Count > 0)
            {
                Console.WriteLine($"{Name}'s Inventory:");
                foreach (var item in Inventory.Items)
                {
                    Console.WriteLine($"- {item.Name}: {item.Description}");
                }
            }
            else
            {
                Console.WriteLine($"{Name}'s inventory is empty.");
            }


        }


    }



}
