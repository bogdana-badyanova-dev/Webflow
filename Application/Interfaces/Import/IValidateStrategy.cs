using Webflow.API.Dto.Shared;

namespace Webflow.Application.Interfaces.Import
{

    public interface IValidateStrategy
    {
  
        Task<BaseResponse<bool>> Validate(IImportResult model, CancellationToken cancellationToken = default);
    }
}
