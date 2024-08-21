using Webflow.API.Dto.Import;
using Webflow.API.Dto.Shared;
using Webflow.Application.Interfaces;
using Webflow.Application.Interfaces.Import;

namespace Webflow.Application.Helpers
{
    public class MoodleValidateStrategy : IValidateStrategy
    {
        public Task<BaseResponse<bool>> Validate(IImportResult model, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
