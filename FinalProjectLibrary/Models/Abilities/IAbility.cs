using FinalProjectLibrary.Models.Attributes;
using FinalProjectLibrary.Models.Characters;

namespace FinalProjectLibrary.Models.Abilities
{
    public interface IAbility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Damage { get; set; }
        public void UseAbility(ICharacter user, ITargetable target);
    }
}
