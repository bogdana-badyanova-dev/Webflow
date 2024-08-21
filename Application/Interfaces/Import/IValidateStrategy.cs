using Webflow.API.Dto.Shared;

namespace Webflow.Application.Interfaces.Import
{
    public interface IValidateStrategy
    {
        public Task<BaseResponse<bool>> Validate(IImportResult model, CancellationToken cancellationToken = default);
    }
}
