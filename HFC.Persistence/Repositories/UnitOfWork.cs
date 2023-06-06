
using HFC.Application.Contracts.Persistence;

namespace HFC.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HFCDbContext _context;

        private ITaskRepository _taskRepository;

        private IStaffRepository _staffRepository;



        public UnitOfWork(HFCDbContext context)
        {
            _context = context;
        }


        public ITaskRepository TaskRepository
        {
            get
            {
                return _taskRepository ??= new TaskRepository(_context);
            }
        }

        public IStaffRepository StaffRepository
        {
            get
            {
                return _staffRepository ??= new StaffRepository(_context);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}