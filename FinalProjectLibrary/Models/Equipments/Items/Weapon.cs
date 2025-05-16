using FinalProjectLibrary.Models.Characters.Players;

namespace FinalProjectLibrary.Models.Equipments.Items
{
    public class Weapon : Item
    {
        public int Damage { get; set; }
        public int DamageOverTime { get; set; }

        public override void Use(Player player)
        {
            Console.WriteLine($"{player.Name} equips {Name}.");
            player.EquipWeapon(this);
        }
    }
}
