using MediatR;
using TaskManagementSystem.Application.Common.Interfaces;
using TaskManagementSystem.Application.Common.Interfaces.IServices;
using TaskManagementSystem.Application.Features.Users.Commands;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Features.Users.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FullName = request.FullName,
                Username = request.Email,
                Email = request.Email,
                Role = request.Role
            };

            user.PasswordHash = _userService.HashPassword(user, request.Password);

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return user.Id;
        }
    }
}
