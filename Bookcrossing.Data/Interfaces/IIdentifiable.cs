namespace Bookcrossing.Data.Interfaces
{
    public interface IIdentifiable<TIdentifierType>
    {
        TIdentifierType Id { get; set; }
    }
}
