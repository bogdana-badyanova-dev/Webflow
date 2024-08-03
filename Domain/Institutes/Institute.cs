using Webflow.Domain.Shared;

namespace Webflow.Domain.Institutes
{
    public class Institute : BaseEntity<Guid>
    {
        public string Name { get; set; }
    }
}
