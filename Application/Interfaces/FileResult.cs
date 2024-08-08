namespace Webflow.Application.Interfaces
{
    public class FileResult
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }
}
