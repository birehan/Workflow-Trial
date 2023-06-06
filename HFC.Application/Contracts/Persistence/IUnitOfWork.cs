

namespace HFC.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ITaskRepository TaskRepository{get;} 

        IStaffRepository StaffRepository{get;} 


        
        Task<int> Save();

    }
}