using MediatR;
using TaskManagementSystem.Application.Features.Users.Dtos;

namespace TaskManagementSystem.Application.Features.Users.Queries
{
    public class GetAllUsersQuery : IRequest<List<UserDto>> { }
}
