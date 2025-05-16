using FinalProjectLibrary.Models.Attributes;
using FinalProjectLibrary.Models.Rooms;

namespace FinalProjectLibrary.Models.Characters
{
    public interface ICharacter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int? RoomId { get; set; }
        public Room Room { get; set; }
        void Attack(ITargetable target);

    }
}
