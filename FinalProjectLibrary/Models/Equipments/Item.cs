using FinalProjectLibrary.Models.Characters.Players;
using FinalProjectLibrary.Models.Rooms;

namespace FinalProjectLibrary.Models.Equipments
{
    public abstract class Item : IItem
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Type { get; set; }
        public int? RoomId { get; set; }
        public virtual Room? Room { get; set; }
        public int? InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }

        public abstract void Use(Player player);

    }
}
