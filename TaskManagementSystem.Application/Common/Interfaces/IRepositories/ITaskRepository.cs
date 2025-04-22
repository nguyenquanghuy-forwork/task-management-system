using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Application.Common.Interfaces.IRepositories
{
    public interface ITaskRepository : IGenericRepository<Domain.Entities.TaskItem>
    {
        Task<IReadOnlyList<Domain.Entities.TaskItem>> GetTasksByProjectIdAsync(Guid? projectId);
    }
}
