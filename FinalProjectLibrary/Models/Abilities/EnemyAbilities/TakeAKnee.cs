using FinalProjectLibrary.Models.Attributes;
using FinalProjectLibrary.Models.Characters;
using FinalProjectLibrary.Models.Characters.Enemy;

namespace FinalProjectLibrary.Models.Abilities.EnemyAbilities
{
    public class TakeAKnee : EnemyAbility
    {
        public override void UseAbility(ICharacter user, ITargetable target)
        {
            if (user is Tyrant)
            {
                Console.WriteLine($"\n{user.Name} takes a knee, unable to fight for now.", ConsoleColor.Yellow);
            }
        }
    }
}
