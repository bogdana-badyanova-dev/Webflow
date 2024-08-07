using Webflow.Application.Messages.ErrorMessages;

namespace Webflow.Application.Messages.ErrorMessages.Students
{
    /// <summary>
    /// Абстрактный класс, содержащий сообщения об ошибках, специфичные для операций со студентами.
    /// Наследует общие сообщения об ошибках из класса <see cref="CommonErrorMessages"/>.
    /// </summary>
    public abstract class InstituteErrorMessages : CommonErrorMessages
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
        /// Сообщение об ошибке, когда институт не может быть удален.
        /// </summary>
        public const string INSTITUTE_CANNOT_CREATE = "Институт не может быть создан";


    }

}
