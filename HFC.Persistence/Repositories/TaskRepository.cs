using Microsoft.EntityFrameworkCore;
using HFC.Application.Contracts.Persistence;

namespace HFC.Persistence.Repositories
{
    public class TaskRepository : GenericRepository<Domain.Task>, ITaskRepository
    {

        private readonly HFCDbContext _dbContext;

        public TaskRepository(HFCDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Domain.Task>> GetAll()
        {
            return await _dbContext.Set<Domain.Task>().Include(x => x.Creator).AsNoTracking().ToListAsync();
        }


        public async Task<Domain.Task> Get(Guid id)
        {
            return await _dbContext.Set<Domain.Task>().Include(x => x.Creator).FirstOrDefaultAsync(b => b.Id == id);
        }

    }
}