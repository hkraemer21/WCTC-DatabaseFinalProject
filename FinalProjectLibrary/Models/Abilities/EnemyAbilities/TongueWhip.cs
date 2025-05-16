using FinalProjectLibrary.Models.Attributes;
using FinalProjectLibrary.Models.Characters;
using FinalProjectLibrary.Models.Characters.Enemy;

namespace FinalProjectLibrary.Models.Abilities.EnemyAbilities
{
    public class TongueWhip : EnemyAbility
    {
        public override void UseAbility(ICharacter user, ITargetable target)
        {
            if (user is Licker)
            {
                Console.WriteLine($"\n{user.Name} lashes out its long tongue and whips {target.Name}.", ConsoleColor.Yellow);
                Console.WriteLine($"{target.Name} Health: - -", ConsoleColor.Red);
                target.Health -= Damage;
            }
        }
    }
}
