using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Common.Interfaces.IRepositories
{
    public interface IUserRepository : IGenericRepository<User> { }
}
