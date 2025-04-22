using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Common.Interfaces.IRepositories;
using TaskManagementSystem.Domain.Entities;
using TaskManagementSystem.Infrastructure.Persistence;

namespace TaskManagementSystem.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }
    }
}
