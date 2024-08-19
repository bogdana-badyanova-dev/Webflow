namespace Webflow.API.Dto.Import
{
    /// <summary>
    /// Представляет результаты файла, включая имя, тип контента и содержимое
    /// </summary>
    public class FileResult
    {
        /// <summary>
        /// Имя файла
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Тип контента файла
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Содержимое файла в виде массива байтов
        /// </summary>
        public byte[] Content { get; set; }
    }
}
