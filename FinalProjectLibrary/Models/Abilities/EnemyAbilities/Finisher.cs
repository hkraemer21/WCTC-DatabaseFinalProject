using FinalProjectLibrary.Models.Attributes;
using FinalProjectLibrary.Models.Characters;
using FinalProjectLibrary.Models.Characters.Enemy;

namespace FinalProjectLibrary.Models.Abilities.EnemyAbilities
{
    public class Finisher : EnemyAbility
    {
        public override void UseAbility(ICharacter user, ITargetable target)
        {
            if (user is Zombie)
            {
                Console.WriteLine($"\n{user.Name} tears {target.Name}'s throat out.", ConsoleColor.Red);
                target.Health = 0;
            }
            else if (user is Licker)
            {
                Console.WriteLine($"\n{user.Name} tackles {target.Name} to the ground and chomps its razor-sharp teeth down on their head.", ConsoleColor.Red);
                target.Health = 0;
            }
            else if (user is Tyrant)
            {
                Console.WriteLine($"\n{user.Name} grabs {target.Name}'s head with both hands and crushes their skull.", ConsoleColor.Red);
                target.Health = 0;
            }
        }
    }
}
