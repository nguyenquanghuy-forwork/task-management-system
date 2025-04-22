using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Common.Interfaces;
using TaskManagementSystem.Application.Features.Users.Commands;

namespace TaskManagementSystem.Application.Features.Users.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.Where(u=>u.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (user == null)
                throw new DataException("User not found");

            await _unitOfWork.Users.RemoveAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
