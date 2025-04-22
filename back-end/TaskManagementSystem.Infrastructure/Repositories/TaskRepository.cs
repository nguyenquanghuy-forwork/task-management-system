using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Common.Interfaces.IRepositories;
using TaskManagementSystem.Infrastructure.Persistence;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class TaskRepository : GenericRepository<Domain.Entities.TaskItem>, ITaskRepository
    {
        public TaskRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IReadOnlyList<Domain.Entities.TaskItem>> GetTasksByProjectIdAsync(Guid? projectId)
        {
            return await _dbContext.TaskItems
                .Where(t => t.ProjectId == projectId)
                .ToListAsync();
        }
    }
}
