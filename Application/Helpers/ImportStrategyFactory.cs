using Webflow.Application.Enums;
using Webflow.Application.Interfaces;
using Webflow.Application.Interfaces.Import;

namespace Webflow.Application.Helpers
{
    public class ImportStrategyFactory : IImportStrategyFactory<IImportResult>
    {
        private readonly IServiceProvider _serviceProvider;

        public ImportStrategyFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IImportStrategy<IImportResult> CreateStrategy(PlatformEnum source)
        {
            return source switch
            {
                PlatformEnum.MOODLE => _serviceProvider.GetRequiredService<MoodleImportStrategy>(),
                PlatformEnum.INNOPOLIS => _serviceProvider.GetRequiredService<InnopolisImportStrategy>(),
                _ => throw new ArgumentException("Неизвестный источник импорта", nameof(source))
            };
        }
    }
}
