using FinalProjectLibrary.Models.Attributes;
using FinalProjectLibrary.Models.Characters;
using FinalProjectLibrary.Models.Characters.Enemy;

namespace FinalProjectLibrary.Models.Abilities.PlayerAbilities
{
    public class KneeKick : PlayerAbility
    {
        public override void UseAbility(ICharacter user, ITargetable target)
        {
            if (target is Zombie)
            {

                Console.WriteLine($"\n{user.Name} kicks {target.Name}'s knee out from under them, making them fall.", ConsoleColor.Yellow);
                target.TakeDamage(Damage);

            }
            else if (target is Licker)
            {

                Console.WriteLine($"\n{user.Name} cannot reach {target.Name}'s knee, so they kick them in the face, knocking {target.Name} back.", ConsoleColor.Yellow);
                target.TakeDamage(Damage);

            }
            else if (target is Tyrant)
            {

                Console.WriteLine($"\nGetting close to {target.Name} is foolish, aborting plan to kick.", ConsoleColor.Red);

            }
        }
    }
}
