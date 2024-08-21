using Webflow.API.Dto.Import;
using Webflow.API.Dto.Shared;
using Webflow.Application.Interfaces;
using Webflow.Application.Interfaces.Import;

namespace Webflow.Application.Helpers
{
    public class InnopolisValidationStrategy : IValidationStrategy
    {
        public Task<BaseResponse<bool>> Validate(IImportResult result, CancellationToken cancellationToken = default)
        {
            var importResult = result as InnopolisImportResult;
            if (importResult == null)
            {
                // TODO
                throw new InvalidCastException("Invalid model type provided.");
            }

            var model = importResult.Data;

            throw new NotImplementedException();
        }
    }
}
