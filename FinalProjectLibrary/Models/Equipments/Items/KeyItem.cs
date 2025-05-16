using FinalProjectLibrary.Models.Characters.Players;

namespace FinalProjectLibrary.Models.Equipments.Items
{
    public class KeyItem : Item
    {
        public bool WasUsed { get; set; }

        public override void Use(Player player)
        {
            Console.WriteLine($"{player.Name} uses {Name}");
            WasUsed = true;
        }
    }
}
