using Webflow.Application.Messages.ErrorMessages;

namespace Webflow.Application.Messages.ErrorMessages.Students
{
    /// <summary>
    /// Абстрактный класс, содержащий сообщения об ошибках, специфичные для операций со студентами.
    /// Наследует общие сообщения об ошибках из класса <see cref="CommonErrorMessages"/>.
    /// </summary>
    public abstract class StudentErrorMessages : CommonErrorMessages
    {
        /// <summary>
        /// Сообщение об ошибке, когда данные о студенте не найдены.
        /// </summary>
        public const string STUDENT_NOT_FOUND = "Данные о студенте не найдены";

        /// <summary>
        /// Сообщение об ошибке, когда данные о студентах не найдены.
        /// </summary>
        public const string STUDENTS_NOT_FOUND = "Данные о студентах не найдены";

        /// <summary>
        /// Сообщение об ошибке, когда студент не может быть удален.
        /// </summary>
        public const string STUDENT_CANNOT_DELETE = "Студент не может быть удален";
    }

}
