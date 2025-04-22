using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Application.Common.Interfaces;
using TaskManagementSystem.Application.Features.Tasks.Commands;
using TaskManagementSystem.Domain.Entities;
namespace TaskManagementSystem.Application.Features.Tasks.Handlers
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            // Kiểm tra xem ProjectId có tồn tại trong bảng Projects không
            var project = await _unitOfWork.Projects.Where(p => p.Id == request.ProjectId).FirstOrDefaultAsync(cancellationToken);

            // Nếu không tìm thấy ProjectId, tạo Project mới
            if (project == null)
            {
                project = new Project
                {
                    Name = "Default Project", // Bạn có thể thay đổi tên hoặc các thuộc tính khác
                    Description = "Default project created due to missing ProjectId"
                };

                request.ProjectId = project.Id;

                _unitOfWork.Projects.Add(project);
                await _unitOfWork.SaveChangesAsync();  // Lưu Project mới để lấy ProjectId
            }

            var task = new TaskItem
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Status = Domain.Entities.TaskStatus.Done,
                ProjectId = request.ProjectId,
                AssignedToId = request.AssignedToId
            };

            await _unitOfWork.Tasks.AddAsync(task);
            await _unitOfWork.SaveChangesAsync();

            return task.Id;
        }
    }
}
