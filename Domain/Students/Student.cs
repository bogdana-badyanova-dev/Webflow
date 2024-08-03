using Webflow.Application.Enums;
using Webflow.Domain.Groups;
using Webflow.Domain.Institutes;
using Webflow.Domain.Shared;

namespace Webflow.Domain.Students
{
    public class Student : MutableEntity<Guid>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? MoodleAccountId { get; set; }
        public string? InopolisAccountId { get; set; }
        public GenderEnum Gender { get; set; } = GenderEnum.UNDEFINED;
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public Guid InstituteId { get; set; }
        public Institute Institute { get; set; }


    }
}
