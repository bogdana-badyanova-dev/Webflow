using Webflow.API.Dto.Import;
using Webflow.Application.Enums;
using Webflow.Application.Interfaces;
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
        public IValidateStrategy CreateStrategy(PlatformEnum source)
        {
            return source switch
            {
                PlatformEnum.MOODLE => serviceProvider.GetRequiredService<MoodleValidateStrategy>(),
                PlatformEnum.INNOPOLIS => serviceProvider.GetRequiredService<InnopolisValidateStrategy>(),
                _ => throw new ArgumentException("Неизвестный источник импорта", nameof(source))
            };
        }
    }
}
