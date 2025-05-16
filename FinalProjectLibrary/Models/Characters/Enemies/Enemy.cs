using FinalProjectLibrary.Models.Abilities.EnemyAbilities;
using FinalProjectLibrary.Models.Attributes;
using FinalProjectLibrary.Models.Rooms;

namespace FinalProjectLibrary.Models.Characters.Enemy
{
    public abstract class Enemy : ICharacter, ITargetable
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int Health { get; set; }
        public required int AttackPower { get; set; }
        public required string EnemyType { get; set; }
        public int? RoomId { get; set; }
        public Room Room { get; set; }
        public virtual ICollection<EnemyAbility> EnemyAbilities { get; set; }

        public abstract void Attack(ITargetable target);
        public abstract void TakeDamage(int damage);
    }
}
