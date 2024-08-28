using Webflow.Domain.Shared;

namespace Webflow.API.Dto.Institutes
{
    public class GetPagedInstitutesRequest : IPagedRequest
    {
        public required int Page { get; set; }
        public required int Size { get; set; }
    }
}
