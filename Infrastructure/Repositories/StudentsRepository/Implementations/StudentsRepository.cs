using Microsoft.EntityFrameworkCore;
using Webflow.API.Dto.Students;
using Webflow.Application.Enums;
using Webflow.Domain.Shared;
using Webflow.Domain.Students;
using Webflow.Infrastructure.Repositories.BaseRepository.Implementations;
using Webflow.Infrastructure.Repositories.StudentsRepository.Interfaces;

namespace Webflow.Infrastructure.Repositories.StudentsRepository.Implementations
{
    /// <summary>
    /// Репозиторий для работы с сущностями студентов
    /// </summary>
    public class StudentsRepository : BaseRepository<Student>, IStudentsRepository
    {
        /// <summary>
        /// Конструктор класса репозитория студентов
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public StudentsRepository(WebflowContext context) : base(context)
        {
        }

        public async Task<PaginatedResponse<Student>> GetPagedAsync(GetPagedStudentsRequest request, CancellationToken cancellationToken)
        {
            
            IQueryable<Student> query = _dbSet;

            query = query.Where(s => s.RemovedAt == null);

            // Фильтрация по имени, если задано
            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                query = query.Where(s => s.FirstName.Contains(request.Name) || s.LastName.Contains(request.Name));
            }

            // Фильтрация по GroupId, если задано
            if (request.GroupId.HasValue)
            {
                query = query.Where(s => s.GroupId == request.GroupId.Value);
            }

            // Фильтрация по InstituteId, если задано
            if (request.InstituteId.HasValue)
            {
                query = query.Where(s => s.InstituteId == request.InstituteId.Value);
            }

            // Сортировка, если задано
            if (request.Sort != null && request.Sort.Any())
            {
                foreach (var sortField in request.Sort)
                {
                    if (sortField.Direction == SortDirectionEnum.ASC)
                    {
                        query = query.OrderBy(s => EF.Property<object>(s, sortField.FieldName));
                    }
                    else if (sortField.Direction == SortDirectionEnum.DESC)
                    {
                        query = query.OrderByDescending(s => EF.Property<object>(s, sortField.FieldName));
                    }
                }
            }

            var totalCount = await query.CountAsync(cancellationToken);
            var students = await query
                .Skip((request.Page - 1) * request.Size)
                .Take(request.Size)
                .ToListAsync(cancellationToken);

            return new PaginatedResponse<Student>
            {
                Items = students,
                TotalCount = totalCount
            };
        }
    }
}
