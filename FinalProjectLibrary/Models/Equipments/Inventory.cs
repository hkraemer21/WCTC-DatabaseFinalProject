using FinalProjectLibrary.Models.Characters.Players;

namespace FinalProjectLibrary.Models.Equipments
{
    public class Inventory
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public virtual Player? Player { get; set; }
        public virtual ICollection<Item>? Items { get; set; }

        public Inventory()
        {
            Items = new List<Item>();
        }


    }


}
