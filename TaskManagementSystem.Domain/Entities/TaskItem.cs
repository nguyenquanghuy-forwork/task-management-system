using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Domain.Entities
{
    public enum TaskStatus
    {
        Todo = 1,
        InProgress = 2,
        Done = 0
    }

    public class TaskItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }

        // Thêm thuộc tính khóa ngoại cho Project
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }  // Mối quan hệ với Project

        // Thêm thuộc tính khóa ngoại cho User
        public Guid AssignedToId { get; set; }
        public User AssignedTo { get; set; }  // Mối quan hệ với User
    }

}
