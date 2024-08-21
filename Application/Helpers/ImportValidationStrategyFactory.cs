using Webflow.Application.Enums;
using Webflow.Application.Interfaces.Import;

namespace Webflow.Application.Helpers
{
    public class ImportValidationStrategyFactory : IImportValidationStrategyFactory
    {
        private readonly IServiceProvider serviceProvider;

        public ImportValidationStrategyFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public IValidationStrategy CreateStrategy(PlatformEnum source)
        {
            return source switch
            {
                PlatformEnum.MOODLE => serviceProvider.GetRequiredService<MoodleValidationStrategy>(),
                PlatformEnum.INNOPOLIS => serviceProvider.GetRequiredService<InnopolisValidationStrategy>(),
                _ => throw new ArgumentException("Неизвестный источник импорта", nameof(source))
            };
        }
    }
}
