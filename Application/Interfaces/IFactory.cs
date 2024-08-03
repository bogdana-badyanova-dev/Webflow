namespace Webflow.Application.Interfaces
{
    /// <summary>
    /// Интерфейс для фабрики, создающей объекты типа T.
    /// </summary>
    /// <typeparam name="T">Тип создаваемого объекта</typeparam>
    public interface IFactory<T>
    {
        /// <summary>
        /// Создает объект типа T на основе предоставленных данных.
        /// </summary>
        /// <param name="data">Данные для создания объекта</param>
        /// <returns>Созданный объект типа T</returns>
        T Create(T data);
    }
}
