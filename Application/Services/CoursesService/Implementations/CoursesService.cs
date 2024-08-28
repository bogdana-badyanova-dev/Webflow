using AutoMapper;
using Webflow.API.Dto.Courses;
using Webflow.API.Dto.Shared;
using Webflow.Application.Messages.ErrorMessages.Courses;
using Webflow.Application.Services.CoursesService.Interfaces;
using Webflow.Application.Validators.Courses;
using Webflow.Domain.Cources;
using Webflow.Infrastructure.Repositories.CoursesRepository.Interfaces;

namespace Webflow.Application.Services.CoursesService.Implementations
{
    public class CoursesService: ICoursesService
    {
        private readonly ICoursesRepository groupsRepository;
        private readonly IMapper mapper;

        public CoursesService(ICoursesRepository groupsRepository, IMapper mapper)
        {
            this.groupsRepository = groupsRepository;
            this.mapper = mapper;
        }

        public async Task<BaseResponse<CourseView>> Create(CreateCourseRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<CourseView>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>()
            };

            var existingCourse = await groupsRepository.FindAsync(i => i.Name == request.Name, cancellationToken);

            if (existingCourse.Any())
            {
                response.ErrorMessages = new List<string>() { CoursesErrorMessages.COURSE_ALREADY_EXISTS };
                return response;
            }

            var validator = new CreateCourseRequestValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                response.ErrorMessages = validationResult.Errors.Select(e => e.ErrorMessage);
                return response;
            }

            var group = mapper.Map<Course>(request);
            var result = await groupsRepository.AddAsync(group, cancellationToken);

            if (result == Guid.Empty)
            {
                response.ErrorMessages.Append(CoursesErrorMessages.COURSE_CANNOT_CREATE);
                return response;
            }

            response.IsSuccess = true;
            response.Data = mapper.Map<CourseView>(group);

            return response;
        }

        public async Task<BaseResponse<CourseView>> GetById(Guid? id, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<CourseView>()
            {
                IsSuccess = false,
                ErrorMessages = new List<string>()
            };

            if (id == null)
            {
                response.ErrorMessages.Append(CoursesErrorMessages.ID_CANNOT_BE_NULL);
                return response;
            }

            var result = await groupsRepository.GetByIdAsync((Guid)id, cancellationToken);

            if (result == null)
            {
                response.ErrorMessages.Append(CoursesErrorMessages.COURSE_NOT_FOUND);
                return response;
            }

            var data = mapper.Map<CourseView>(result);

            response.IsSuccess = true;
            response.Data = data;
            return response;
        }
    }
}
