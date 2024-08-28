namespace Webflow.Application.Messages.ErrorMessages.Students
{
    /// <summary>
    /// Абстрактный класс, содержащий сообщения об ошибках, специфичные для операций с компетенциями.
    /// Наследует общие сообщения об ошибках из класса <see cref="CommonErrorMessages"/>.
    /// </summary>
    public abstract class SkillErrorMessages : CommonErrorMessages
    {
        /// <summary>
        /// Сообщение об ошибке, когда данные о компетенции не найдены.
        /// </summary>
        public const string SKILL_NOT_FOUND = "Данные о компетенции не найдены";

        /// <summary>
        /// Сообщение об ошибке, когда компетенция не может быть удалена.
        /// </summary>
        public const string SKILL_CANNOT_DELETE = "Компетенция не может быть удалена";

        /// <summary>
        /// Сообщение об ошибке, когда компетенция не может быть создана.
        /// </summary>
        public const string SKILL_CANNOT_CREATE = "Компетенция не может быть создана";

        /// <summary>
        /// Сообщение об ошибке, когда данные об компетенциях не найдены.
        /// </summary>
        public const string SKILLS_NOT_FOUND = "Данные об компетенциях не найдены";

        /// <summary>
        /// Сообщение об ошибке, когда конпетенция с таким наименованием уже существует.
        /// </summary>
        public const string SKILL_ALREADY_EXISTS = "Конпетенция с таким наименованием уже существует";
    }
}
