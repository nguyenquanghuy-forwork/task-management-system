using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid OwnerId { get; set; }
        public User Owner { get; set; }

        public ICollection<TaskItem> TaskItems { get; set; }
    }
}
