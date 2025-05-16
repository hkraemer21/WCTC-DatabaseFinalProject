using FinalProjectLibrary.Models.Characters;
using FinalProjectLibrary.Models.Characters.Enemy;
using FinalProjectLibrary.Models.Characters.Players;

namespace FinalProjectLibrary.Models.Rooms
{
    public interface IRoom
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        ICollection<Player> Players { get; set; }
        ICollection<Enemy> Enemies { get; set; }
        void AddCharacter(ICharacter character);
        void RemoveCharacter(ICharacter character);
    }
}
