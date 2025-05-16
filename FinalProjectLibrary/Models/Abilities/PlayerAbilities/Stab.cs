using FinalProjectLibrary.Models.Attributes;
using FinalProjectLibrary.Models.Characters;
using FinalProjectLibrary.Models.Characters.Enemy;
using FinalProjectLibrary.Models.Characters.Players;

namespace FinalProjectLibrary.Models.Abilities.PlayerAbilities
{
    public class Stab : PlayerAbility
    {
        public override void UseAbility(ICharacter user, ITargetable target)
        {
            if (user is Player)
            {
                if (target is Zombie)
                {

                    Console.WriteLine($"\n{user.Name} plunges their knife into {target.Name}, pulls it out, and shoves them back.", ConsoleColor.Yellow);
                    target.TakeDamage(Damage);

                } else if (target is Licker)
                {

                    Console.WriteLine($"\n{user.Name} plunges their knife into {target.Name}, pulls it out, and kicks them back.", ConsoleColor.Yellow);
                    target.TakeDamage(Damage);

                } else if (target is Tyrant)
                {

                    Console.WriteLine($"\n{user.Name} slices into {target.Name}'s arm, allowing them to escape {target.Name}'s grip.", ConsoleColor.Yellow);
                    target.TakeDamage(Damage);
                }
            }
        }
    }
}
