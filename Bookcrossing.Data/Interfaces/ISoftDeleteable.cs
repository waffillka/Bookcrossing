namespace Bookcrossing.Data.Interfaces
{
    public interface ISoftDeleteable
    {
        public bool isDeleted { get; set; }
    }
}
