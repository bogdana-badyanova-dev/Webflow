using AutoMapper;
using Webflow.API.Dto.Shared;
using Webflow.API.Dto.CourseResults;
using Webflow.Application.Messages.ErrorMessages.Students;
using Webflow.Application.Services.CourseResultsService.Interfaces;
using Webflow.Application.Validators.CourseResults;
using Webflow.Domain.CourseResults;
using Webflow.Infrastructure.Repositories.CourseResultsRepository.Interfaces;
using Webflow.Application.Messages.ErrorMessages.CourseResults;

namespace Webflow.Application.Services.CourseResultsService.Implementations
{
    public class CourseResultsService: ICourseResultsService
    {
        private readonly ICourseResultsRepository courseResultsRepository;
        private readonly IMapper mapper;

        public CourseResultsService(ICourseResultsRepository courseResultsRepository, IMapper mapper)
        {
            this.courseResultsRepository = courseResultsRepository;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<CourseResultView>> Create(CreateCourseResultRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<CourseResultView>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>()
            };

            var existingCourseResult = await courseResultsRepository.FindAsync(i => i.Name == request.Name, cancellationToken);

            if (existingCourseResult.Any())
            {
                response.ErrorMessages = new List<string>() { CourseResultsErrorMessages.COURSE_RESULT_ALREADY_EXISTS };
                return response;
            }

            var validator = new CreateCourseResultRequestValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                response.ErrorMessages = validationResult.Errors.Select(e => e.ErrorMessage);
                return response;
            }

            var courseResult = mapper.Map<CourseResult>(request);
            var result = await courseResultsRepository.AddAsync(courseResult, cancellationToken);

            if (result == Guid.Empty)
            {
                response.ErrorMessages.Append(CourseResultsErrorMessages.COURSE_RESULT_CANNOT_CREATE);
                return response;
            }

            response.IsSuccess = true;
            response.Data = mapper.Map<CourseResultView>(courseResult);

            return response;
        }

        public async Task<BaseResponse<CourseResultView>> GetById(Guid? id, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<CourseResultView>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>()
            };

            if (id == Guid.Empty)
            {
                response.ErrorMessages.Append(CourseResultsErrorMessages.ID_CANNOT_BE_NULL);
                return response;
            }

            var result = await courseResultsRepository.GetByIdAsync((Guid)id, cancellationToken);

            if (result == null)
            {
                response.ErrorMessages.Append(CourseResultsErrorMessages.COURSE_RESULT_NOT_FOUND);
                return response;
            }

            var data = mapper.Map<CourseResultView>(result);

            response.IsSuccess = true;
            response.Data = data;
            return response;
        }
    }
}
