using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Features.Tasks.Dtos;
using TaskManagementSystem.Application.Features.Users.Dtos;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskItem, TaskDto>()
                .ForMember(dest => dest.AssignedTo, opt => opt.MapFrom(src => src.AssignedTo.Username))
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<User, UserDto>();
        }
    }
}
