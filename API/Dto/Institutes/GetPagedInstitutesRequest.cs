using System.ComponentModel.DataAnnotations;
using Webflow.Domain.Shared;

namespace Webflow.API.Dto.Institutes
{
    public class GetPagedInstitutesRequest : IPagedRequest
    {
        public string? Name { get; set; }

        [Required]
        public int Page { get; set; }

        [Required]
        public int Size { get; set; }
    }
}
