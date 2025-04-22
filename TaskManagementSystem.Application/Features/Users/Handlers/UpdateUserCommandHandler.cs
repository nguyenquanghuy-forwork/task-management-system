using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Application.Common.Interfaces;
using TaskManagementSystem.Application.Common.Interfaces.IServices;
using TaskManagementSystem.Application.Features.Users.Commands;

namespace TaskManagementSystem.Application.Features.Users.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.Where(s => s.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (user == null)
                throw new ArgumentNullException("User not found");

            user.FullName = request.FullName;
            user.Email = request.Email;
            user.Role = request.Role;

            user.PasswordHash = _userService.HashPassword(user, request.Password);

            await _unitOfWork.Users.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
