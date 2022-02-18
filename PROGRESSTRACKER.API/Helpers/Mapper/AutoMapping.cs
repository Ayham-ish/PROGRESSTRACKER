using AutoMapper;
using PROGRESSTRACKER.API.Helpers.Mapper.Models;
using PROGRESSTRACKER.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.API.Helpers.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserResponseModel>()
                .ForMember(c => c.FullName, opt => opt.MapFrom(x => string.Join(' ', x.Name, x.Surname)));
            CreateMap<User, PublicUserResponse>()
                .ForMember(c => c.FullName, opt => opt.MapFrom(x => string.Join(' ', x.Name, x.Surname)));
            CreateMap<Client, ClientResponse>();
            CreateMap<DailyReport, DailyReportResponse>();
            CreateMap<Project, ProjectResponse>();
            CreateMap<Project, ProjectNameResponse>();
            CreateMap<TimeTracker, TimeTrackerResponse>();
            CreateMap<TimeTracker, ProjectTimeTrackersResponse>();
            
            CreateMap<TimeTrackerTagRelation, TimeTrackerTagRelationResponse>();
            
           
            CreateMap<Tag, TagResponse>();
            CreateMap<Work, WorkResponse>();
            
        }
    }
}
