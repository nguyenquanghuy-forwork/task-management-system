using MediatR;

namespace TaskManagementSystem.Application.Features.Users.Commands
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public string Password { get; set; }
    }
}
