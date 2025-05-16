using FinalProjectLibrary.Data;
using FinalProjectLibrary.Models.Abilities.EnemyAbilities;
using FinalProjectLibrary.Models.Attributes;
using FinalProjectLibrary.Models.Rooms;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectLibrary.Models.Characters.Enemy
{
    public class Tyrant : Enemy, IUnkillable
    {
        private readonly DbContext _context;
        public int StunThreshold { get; set; }
        public Tyrant(GameContext context)
        {
            _context = context;
        }

        public override void Attack(ITargetable target)
        {
            Console.WriteLine($"{Name} lunges at {target.Name} with a powerful punch, knocking them back.");
            Console.WriteLine($"{target.Name} Health: - -");
            target.Health -= AttackPower;
        }
        public void UnkillableReset()
        {
            Health = 1000;
            Console.WriteLine($"{Name} has stood and resumes his search for you.");

            // TODO: send tyant to random room
        }

        public void CantKill()
        {
            Console.WriteLine($"It is clear {Name} cannot be killed, maybe inflicting enough damage would stun it.", ConsoleColor.Red);

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

            if (ability is TakeAKnee)
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
