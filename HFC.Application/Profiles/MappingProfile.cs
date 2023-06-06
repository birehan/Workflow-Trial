using AutoMapper;
using HFC.Application.Features.Staffs.DTOs;
using HFC.Application.Features.Tasks.DTOs;
using HFC.Domain;

namespace HFC.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskDto, Domain.Task>()
            .ReverseMap()
            .ForMember(x => x.CreatorUsername, o => o.MapFrom(s => s.Creator.UserName));



            CreateMap<CreateTaskDto, Domain.Task>().ReverseMap();
            CreateMap<UpdateTaskDto, Domain.Task>().ReverseMap();

            CreateMap<CreateStaffDto, Staff>().ReverseMap();
            CreateMap<UpdateStaffDto, Staff>().ReverseMap();
            CreateMap<Staff, StaffDto>()
            .ForMember(x => x.PhotoUrl, o => o.MapFrom(s => s.Photo.Url));


        }
    }
}