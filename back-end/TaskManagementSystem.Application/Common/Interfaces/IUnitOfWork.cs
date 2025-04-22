using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Common.Interfaces.IRepositories;

namespace TaskManagementSystem.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        ITaskRepository Tasks { get; }
        IProjectRepository Projects { get; }
        IUserRepository Users { get; }
        Task<int> SaveChangesAsync();
    }
}
