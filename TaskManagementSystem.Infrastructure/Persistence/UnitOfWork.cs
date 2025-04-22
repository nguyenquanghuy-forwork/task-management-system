using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Common.Interfaces;
using TaskManagementSystem.Application.Common.Interfaces.IRepositories;

namespace TaskManagementSystem.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context,
                          ITaskRepository taskRepository,
                          IProjectRepository projectRepository,
                          IUserRepository userRepository)
        {
            _context = context;
            Tasks = taskRepository;
            Projects = projectRepository;
            Users = userRepository;
        }

        public ITaskRepository Tasks { get; private set; }
        public IProjectRepository Projects { get; private set; }
        public IUserRepository Users { get; private set; }

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
