using Webflow.Application.Enums;
using Webflow.Application.Interfaces;
using Webflow.Application.Interfaces.Import;

namespace Webflow.Application.Helpers
{
    /// <summary>
    /// Реализация фабрики стратегий импорта, создающая стратегии импорта на основе предоставленных параметров
    /// </summary>
    /// <remarks>
    /// Этот класс отвечает за создание конкретных стратегий импорта, соответствующих указанным типам данных и платформам
    /// </remarks>
    public class ImportStrategyFactory : IImportStrategyFactory<IImportResult>
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Конструктор фабрики стратегий импорта
        /// </summary>
        /// <param name="serviceProvider">Сервис-провайдер для разрешения зависимостей</param>
        public ImportStrategyFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Создает стратегию импорта в зависимости от указанной платформы
        /// </summary>
        /// <param name="source">Платформа источника импорта</param>
        /// <returns>Стратегия импорта для указанной платформы</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если платформа не поддерживается</exception>
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
