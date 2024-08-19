namespace Webflow.Application.Messages.SuccessefulMessages.Institutes
{
    /// <summary>
    /// Абстрактный класс для успешных сообщений, связанных с институтом.
    /// Наследует общие успешные сообщения от базового класса <see cref="CommonSuccessfulMessages"/>.
    /// </summary>
    public abstract class InstituteSuccessfulMessages : CommonSuccessfulMessages
    {
        /// <summary>
        /// Сообщение об успешном удалении студента.
        /// </summary>
        public const string INSTITUTE_DELETED = "Институт удален";
    }
}
