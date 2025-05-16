using FinalProjectLibrary.Models.Attributes;
using FinalProjectLibrary.Models.Characters;
using FinalProjectLibrary.Models.Characters.Enemy;

namespace FinalProjectLibrary.Models.Abilities.EnemyAbilities
{
    public class Grapple : EnemyAbility
    {
        public override void UseAbility(ICharacter user, ITargetable target)
        {
            if (user is Zombie)
            {
                Console.WriteLine($"\n{user.Name} grabs {target.Name} by the shoulders and tries to bite them.", ConsoleColor.Yellow);
            }
            else if (user is Licker)
            {
                Console.WriteLine($"\n{user.Name} climbs up {target.Name}'s body and tries to tackle them to the ground.", ConsoleColor.Yellow);
            }
            else if (user is Tyrant)
            {
                Console.WriteLine($"\n{user.Name} grabs {target.Name} by the throat.", ConsoleColor.Yellow);
            }
        }
    }
}
