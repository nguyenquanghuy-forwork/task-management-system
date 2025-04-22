using MediatR;

namespace TaskManagementSystem.Application.Features.Users.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
