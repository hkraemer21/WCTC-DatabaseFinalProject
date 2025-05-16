using FinalProjectLibrary.Models.Attributes;
using FinalProjectLibrary.Models.Characters;
using FinalProjectLibrary.Models.Characters.Players;

namespace FinalProjectLibrary.Models.Abilities.PlayerAbilities
{
    public abstract class PlayerAbility : IAbility
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required int Damage { get; set; }
        public virtual ICollection<Player>? Players { get; set; }
        public abstract void UseAbility(ICharacter user, ITargetable target);
    }
}
