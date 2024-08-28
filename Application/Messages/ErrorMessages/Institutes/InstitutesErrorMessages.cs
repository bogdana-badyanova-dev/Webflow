namespace Webflow.Application.Messages.ErrorMessages.Students
{
    /// <summary>
    /// Абстрактный класс, содержащий сообщения об ошибках, специфичные для операций со студентами.
    /// Наследует общие сообщения об ошибках из класса <see cref="CommonErrorMessages"/>.
    /// </summary>
    public abstract class InstitutesErrorMessages : CommonErrorMessages
    {
        /// <summary>
        /// Сообщение об ошибке, когда данные о институте не найдены.
        /// </summary>
        public const string INSTITUTE_NOT_FOUND = "Данные о институте не найдены";

        /// <summary>
        /// Сообщение об ошибке, когда институт не может быть удален.
        /// </summary>
        public const string INSTITUTE_CANNOT_DELETE = "Институт не может быть удален";

        /// <summary>
        /// Сообщение об ошибке, когда институт не может быть создана.
        /// </summary>
        public const string INSTITUTE_CANNOT_CREATE = "Институт не может быть создан";

        /// <summary>
        /// Сообщение об ошибке, когда данные об институтах не найдены.
        /// </summary>
        public const string INSTITUTES_NOT_FOUND = "Данные об институтах не найдены";
        
        /// <summary>
        /// Сообщение об ошибке, когда институт с таким наименованием уже существует.
        /// </summary>
        public const string INSTITUTE_ALREADY_EXISTS = "Институт с таким наименованием уже существует";
    }
}
