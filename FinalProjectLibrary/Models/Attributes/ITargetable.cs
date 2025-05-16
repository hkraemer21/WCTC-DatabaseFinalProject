namespace FinalProjectLibrary.Models.Attributes
{
    public interface ITargetable
    {
        string Name { get; set; }
        int Health { get; set; }

        public abstract void TakeDamage(int damage);
    }
}
