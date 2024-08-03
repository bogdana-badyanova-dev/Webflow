namespace Webflow.Domain.Shared
{
    public abstract class MutableEntity<TId> : BaseEntity<TId>
    {
        public DateTime? UpdatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }
    }
}
