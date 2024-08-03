using AutoMapper;
using Webflow.API.Dto;
using Webflow.Domain.Students;

namespace Webflow.Application.Mappings
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile() {
            CreateMap<Student, StudentViewDto>();
        }
    }
}
