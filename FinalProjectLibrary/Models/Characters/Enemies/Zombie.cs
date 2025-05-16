using FinalProjectLibrary.Models.Abilities.EnemyAbilities;
using FinalProjectLibrary.Models.Attributes;
using FinalProjectLibrary.Models.Rooms;

namespace FinalProjectLibrary.Models.Characters.Enemy
{
    public class Zombie : Enemy
    {

        public override void Attack(ITargetable target)
        {
            Console.WriteLine($"{Name} lunges at {target.Name} and bites down on their flesh.");
            Console.WriteLine($"{target.Name} Health: - -");
            target.Health -= AttackPower;
        }

        public override void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} Health: - -");
            if (Health <= 0)
            {
                Console.WriteLine($"{Name} has been defeated!", ConsoleColor.Red);
                Room.RemoveCharacter(this);
            }
        }

        public void UseAbility(EnemyAbility ability, ITargetable target)
        {

            if (ability is Fall)
            {
                ability.UseAbility(this, target);
            }
            else if (ability is Grapple)
            {
                ability.UseAbility(this, target);
            }
            else if (ability is Finisher)
            {
                ability.UseAbility(this, target);
            }
            else
            {
                Console.WriteLine($"{Name} cannot use this ability.");
            }


        }

    }
}
