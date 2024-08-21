using Webflow.API.Dto.Import;
using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Import
{
    /// <summary>
    /// Фабрика стратегий импорта данных, предоставляющая метод для создания стратегии импорта на основе источника
    /// </summary>
    /// <typeparam name="T">Тип результата импорта, реализующий <see cref="IImportResult"/></typeparam>
    public interface IImportStrategyFactory<T> where T : IImportResult
    {
        /// <summary>
        /// Создает стратегию импорта данных на основе указанного источника
        /// </summary>
        /// <param name="source">Источник данных для импорта</param>
        /// <returns>Стратегия импорта данных для указанного источника</returns>
        public IImportStrategy<T> CreateStrategy(PlatformEnum source);
    }
}
