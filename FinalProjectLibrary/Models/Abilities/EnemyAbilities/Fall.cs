using FinalProjectLibrary.Models.Attributes;
using FinalProjectLibrary.Models.Characters.Enemy;
using FinalProjectLibrary.Models.Characters;

namespace FinalProjectLibrary.Models.Abilities.EnemyAbilities
{
    public class Fall : EnemyAbility
    {
        public override void UseAbility(ICharacter user, ITargetable target)
        {
            if (user is Zombie)
            {
                Console.WriteLine($"\n{user.Name} staggers and faceplants on the ground.", ConsoleColor.Yellow);
                Console.WriteLine($"{user.Name} Health: - -", ConsoleColor.Red);
            }
        }

    }
}
