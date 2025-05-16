using FinalProjectLibrary.Data;
using FinalProjectLibrary.Models.Characters.Players;
using FinalProjectLibrary.Models.Equipments.Items;

namespace FinalProject.Services
{
    public class PlayerFactory
    {
        private readonly GameContext _context;
        public PlayerFactory(GameContext context) 
        {
            _context = context;

        }

        public void InitializePlayer(Player player)
        {
            

            if (player.Name == "Claire Redfield")
            {
                var defaultWeapon = _context.Items.FirstOrDefault(i => i.Id == 2);
                if (defaultWeapon is Weapon weapon)
                {
                    player.AddToInventory(weapon);
                    player.EquipWeapon(weapon);
                }
            } else
            {
                var defaultWeapon = _context.Items.FirstOrDefault(i => i.Id == 1);
                if (defaultWeapon is Weapon weapon)
                {
                    player.AddToInventory(weapon);
                    player.EquipWeapon(weapon);
                }
            }
           

            var defaultAbility = _context.PlayerAbilities.FirstOrDefault(a => a.Id == 1);
            if (player.PlayerAbilities.Contains(defaultAbility))
            {
                player.PlayerAbilities.Remove(defaultAbility);
            }
            player.PlayerAbilities.Add(defaultAbility);
            player.Room = _context.Rooms.FirstOrDefault(r => r.Id == 1);


        }
    }
}
