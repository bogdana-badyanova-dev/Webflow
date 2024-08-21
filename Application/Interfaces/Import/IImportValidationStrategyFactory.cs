using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Import
{
    public interface IImportValidationStrategyFactory
    {
        public IValidationStrategy CreateStrategy(PlatformEnum source);  
    }
}
