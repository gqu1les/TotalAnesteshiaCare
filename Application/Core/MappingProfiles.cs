using System;
using Application.TotalAnesthesia.DTO;
using AutoMapper;
using Domain;

namespace Application.Core;

public class MappingProfiles : Profile
{

    public MappingProfiles()
    {
        CreateMap<Activity, Activity>();
        CreateMap<CreateActivityDto, Activity>();
        CreateMap<EditActivityDTO, Activity>();
    }

}
