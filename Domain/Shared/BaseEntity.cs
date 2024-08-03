namespace Webflow.Domain.Shared
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
