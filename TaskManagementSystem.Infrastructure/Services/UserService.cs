using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Application.Common.Interfaces;
using TaskManagementSystem.Application.Common.Interfaces.IServices;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IPasswordHasher<User> passwordHasher, IUnitOfWork unitOfWork)
        {
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
        }

        public string HashPassword(User user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        public bool VerifyPassword(User user, string hashedPassword, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }

        public async Task<User> AuthenticateUserAsync(string email, string password)
        {
            var user = await _unitOfWork.Users.Where(e => e.Email == email).Select(s => new User()
            {
                Email = s.Email,
                FullName = s.FullName,
                Id = s.Id,
                PasswordHash = s.PasswordHash,
                Role = s.Role,
            }).FirstOrDefaultAsync();

            if (user == null)
                return null;

            if (_passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) != PasswordVerificationResult.Success)
            {
                return null;
            }

            return user;
        }
    }
}
