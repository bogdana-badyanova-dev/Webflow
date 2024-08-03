using AutoMapper;
using Webflow.API.Dto;
using Webflow.Application.Mappings;
using Webflow.Application.Services.StudentsService.Interfaces;
using Webflow.Application.Shared.Exceptions;
using Webflow.Infrastructure.Repositories.StudentsRepository.Interfaces;

namespace Webflow.Application.Services.StudentsService.Implementations
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentsRepository studentsRepository;
        private readonly IMapper mapper;
        public StudentsService(IMapper mapper,IStudentsRepository studentsRepository) {
            this.studentsRepository = studentsRepository;
            this.mapper = mapper;
        }
        public async Task<StudentViewDto> getStudentById(Guid id)
        {
            var result = await studentsRepository.GetByIdAsync(id);
            if (result == null) {
                throw new NotFoundException("User not found");
            }
            return mapper.Map<StudentViewDto>(result);
        }
    }
}
   