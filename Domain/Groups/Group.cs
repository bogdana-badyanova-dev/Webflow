using Webflow.Domain.Shared;
using Webflow.Domain.Students;

namespace Webflow.Domain.Groups
{
    public class Group: MutableEntity <Guid>
    {
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }


    }
}
