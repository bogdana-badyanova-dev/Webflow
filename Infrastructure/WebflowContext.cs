using Microsoft.EntityFrameworkCore;
using Webflow.Domain.Institutes;
using Webflow.Domain.Groups;
using Webflow.Domain.Students;

namespace Webflow.Infrastructure
{
    public class WebflowContext : DbContext
    {
        public WebflowContext(DbContextOptions<WebflowContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.Files.File> Files { get; set; } = default!;
        public DbSet<Student> Students { get; set; } = default!;
        public DbSet<Group> Groups { get; set; } = default!;
        public DbSet<Institute> Institutes { get; set; } = default!;
    }
}
