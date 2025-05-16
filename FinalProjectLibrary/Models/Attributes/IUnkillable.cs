namespace FinalProjectLibrary.Models.Attributes
{
    public interface IUnkillable
    {
        public int StunThreshold { get; set; }
        void UnkillableReset();
        void CantKill();
    }
}
