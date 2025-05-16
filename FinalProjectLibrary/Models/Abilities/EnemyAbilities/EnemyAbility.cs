using FinalProjectLibrary.Models.Attributes;
using FinalProjectLibrary.Models.Characters;
using FinalProjectLibrary.Models.Characters.Enemy;

namespace FinalProjectLibrary.Models.Abilities.EnemyAbilities
{
    public abstract class EnemyAbility : IAbility
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public required string Description { get; set; }
        public required int Damage { get; set; }
        public virtual ICollection<Enemy>? Enemies { get; set; }
        public abstract void UseAbility(ICharacter user, ITargetable target);

    }
}
