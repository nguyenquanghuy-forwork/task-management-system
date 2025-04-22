using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Features.Tasks.Dtos;

namespace TaskManagementSystem.Application.Features.Tasks.Queries
{
    public class GetTaskListQuery : IRequest<List<TaskDto>>
    {
        public Guid? ProjectId { get; set; }
        public TaskStatus? Status { get; set; }
        public Guid? AssignedToId { get; set; }
    }
}
