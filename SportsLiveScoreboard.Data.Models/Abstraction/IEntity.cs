namespace SportsLiveScoreboard.Data.Models.Abstraction
{
    public interface IEntity
    {
        object Id { get; }
    }

    public interface IEntity<TKey> : IEntity
    {
        new TKey Id { get; }
    }
}