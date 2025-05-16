using FinalProjectLibrary.Models.Attributes;
using FinalProjectLibrary.Models.Characters;
using FinalProjectLibrary.Models.Characters.Enemy;
using FinalProjectLibrary.Models.Characters.Players;

namespace FinalProjectLibrary.Models.Abilities.PlayerAbilities
{
    public class Roundhouse : PlayerAbility
    {
        public override void UseAbility(ICharacter user, ITargetable target)
        {
            if (user is Player)
            {
                if (target is Zombie)
                {
                    Console.WriteLine($"\n{user.Name} roundhouse kicks {target.Name} in the chest, knocking them back.", ConsoleColor.Yellow);
                    target.TakeDamage(Damage);

                } else if (target is Licker)
                {

                    Console.WriteLine($"\n{user.Name} roundhouse kicks {target.Name} in the face, knocking them back.", ConsoleColor.Yellow);
                    target.TakeDamage(Damage);

                } else if (target is Tyrant)
                {
                    Console.WriteLine($"\n{user.Name} kicks {target.Name} in the stomach, but they remain unmoved.", ConsoleColor.Red);
                }
            }
        }
    }
}
