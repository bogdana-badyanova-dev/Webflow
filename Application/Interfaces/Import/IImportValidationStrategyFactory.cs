using Webflow.Application.Enums;

namespace Webflow.Application.Interfaces.Import
{
    public interface IImportValidationStrategyFactory
    {
        public IValidateStrategy CreateStrategy(PlatformEnum source);  
    }
}
