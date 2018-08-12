using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsLiveScoreboard.Data.Models.Abstraction
{
    public abstract class EntityBase<TKey> : IEntity<TKey>
    {
        [Key]
        public TKey Id { get; protected set; }
        [NotMapped]
        object IEntity.Id => Id;
    }
}