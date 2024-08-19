namespace Webflow.Application.Messages.SuccessefulMessages.Students
{
    /// <summary>
    /// Абстрактный класс для успешных сообщений, связанных со студентом.
    /// Наследует общие успешные сообщения от базового класса <see cref="CommonSuccessfulMessages"/>.
    /// </summary>
    public abstract class StudentSuccessfulMessages : CommonSuccessfulMessages
    {
        /// <summary>
        /// Сообщение об успешном удалении студента.
        /// </summary>
        public const string STUDENT_DELETED = "Студент удален";
    }
}
