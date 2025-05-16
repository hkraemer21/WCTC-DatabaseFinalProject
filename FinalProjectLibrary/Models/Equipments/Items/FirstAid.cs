using FinalProject.Helpers;
using FinalProjectLibrary.Models.Characters.Players;

namespace FinalProjectLibrary.Models.Equipments.Items
{
    public class FirstAid : Item
    {
        private readonly OutputManager _outputManager;
        public int Healing { get; set; }

        public override void Use(Player player)
        {
            if (player.Health < 100)
            {
                if (player.Inventory != null && player.Inventory.Items != null)
                {
                    bool hasFirstAid = player.Inventory.Items.Any(item => item.Name == "FirstAid");
                    if (hasFirstAid)
                    {
                        var healthItem = player.Inventory.Items.FirstOrDefault(item => item.Name == "FirstAid");
                        if (healthItem != null)
                        {
                            if (healthItem is FirstAid firstAidItem)
                            {
                                _outputManager.WriteLine($"{player.Name} uses {firstAidItem.Name} to heal.", ConsoleColor.Green);
                                _outputManager.WriteLine($"{player.Name} Health: + +", ConsoleColor.Green);
                                player.Health += firstAidItem.Healing;
                                if (player.Health > 100)
                                {
                                    player.Health = 100;
                                }
                                _outputManager.WriteLine($"{player.Name} Health: {player.Health}", ConsoleColor.Red);
                                _outputManager.Display();
                            }
                            else
                            {
                                _outputManager.WriteLine($"{player.Name} does not have any first aid.", ConsoleColor.Red);
                            }


                        }
                        else
                        {
                            _outputManager.WriteLine($"{player.Name} does not have any first aid.", ConsoleColor.Red);
                        }
                    }
                }
                else
                {
                    _outputManager.WriteLine($"{player.Name} has plenty of health.", ConsoleColor.Red);
                    _outputManager.Display();
                }
            }
        }
    }
}
