using Microsoft.EntityFrameworkCore;
using Webflow.Domain.Institutes;
using Webflow.Domain.Groups;
using Webflow.Domain.Students;
using Webflow.Domain.Cources;
using Webflow.Domain.Skills;

namespace Webflow.Infrastructure
{
    /// <summary>
    /// Контекст базы данных для приложения Webflow
    /// Наследуется от DbContext и используется для управления сущностями и взаимодействия с базой данных
    /// </summary>
    public class WebflowContext : DbContext
    {
        /// <summary>
        /// Инициализирует новый экземпляр контекста базы данных с указанными параметрами
        /// </summary>
        /// <param name="options">Опции для конфигурации контекста базы данных</param>
        public WebflowContext(DbContextOptions<WebflowContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Представление таблицы файлов в базе данных
        /// </summary>
        public DbSet<Domain.Files.File> Files { get; set; } = default!;

        /// <summary>
        /// Представление таблицы студентов в базе данных
        /// </summary>
        public DbSet<Student> Students { get; set; } = default!;

        /// <summary>
        /// Представление таблицы групп в базе данных
        /// </summary>
        public DbSet<Group> Groups { get; set; } = default!;

        /// <summary>
        /// Представление таблицы институтов в базе данных
        /// </summary>
        public DbSet<Institute> Institutes { get; set; } = default!;

        /// <summary>
        /// Представляет таблицу курсов в базе данных
        /// </summary>
        public DbSet<Course> Courses { get; set; } = default!;

        /// <summary>
        /// Представляет таблицу навыков в базе данных
        /// </summary>
        public DbSet<Skill> Skill { get; set; } = default!;

        /// <summary>
        /// Представление таблицы элементов курсов в СДО СевГУ в базе данных
        /// </summary>
        public DbSet<MoodleCourseElement> MoodleCourseElements { get; set; } = default!;
    }
}
