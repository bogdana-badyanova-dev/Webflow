using Microsoft.EntityFrameworkCore;
using Webflow.API.Dto.Institutes;
using Webflow.Domain.Institutes;
using Webflow.Domain.Shared;
using Webflow.Infrastructure.Repositories.BaseRepository.Implementations;
using Webflow.Infrastructure.Repositories.InstitutesRepository.Interfaces;

namespace Webflow.Infrastructure.Repositories.InstitutesRepository.Implementations
{
    /// <summary>
    /// Репозиторий для работы с сущностями <see cref="Institute"/>.
    /// Наследует базовые методы работы с сущностями от <see cref="BaseRepository{T}"/>.
    /// </summary>
    public class InstitutesRepository : BaseRepository<Institute>, IInstitutesRepository
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="InstitutesRepository"/>.
        /// </summary>
        /// <param name="context">Контекст базы данных для работы с сущностями <see cref="Institute"/>.</param>
        public InstitutesRepository(WebflowContext context) : base(context)
        {
        }

        // TODO
        public async Task<PaginatedResponse<Institute>> GetPagedAsync(GetPagedInstitutesRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Institute> query = _dbSet;

            var totalCount = await query.CountAsync(cancellationToken);
            var institutes = await query
                .Skip((request.Page - 1) * request.Size)
                .Take(request.Size)
                .ToListAsync(cancellationToken);

            return new PaginatedResponse<Institute>
            {
                Items = institutes,
                TotalCount = totalCount
            };
        }
    }
}
