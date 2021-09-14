namespace Bookcrossing.Data.Interfaces
{
    public interface ISoftDeleteable
    {
        public bool IsDeleted { get; set; }
    }
}
