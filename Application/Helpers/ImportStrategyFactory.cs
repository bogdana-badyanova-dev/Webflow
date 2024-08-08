using Webflow.API.Dto.Import;
using Webflow.Application.Enums;
using Webflow.Application.Interfaces;
using Webflow.Application.Interfaces.Import;

namespace Webflow.Application.Helpers
{
    public class ImportStrategyFactory : IImportStrategyFactory<ImportResult>
    {
        private readonly IServiceProvider _serviceProvider;

        public ImportStrategyFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IImportStrategy<ImportResult> CreateStrategy(PlatformEnum source, IEnumerable<FieldMapping> mappings, CancellationToken cancellationToken)
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
