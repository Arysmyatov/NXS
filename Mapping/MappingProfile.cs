using AutoMapper;
using NXS.Controllers.Resources;
using NXS.Models;

namespace NXS.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Region, RegionResource>();
            CreateMap<ParentRegion, ParentRegionResource>();
            CreateMap<Scenario, ScenarioResource>();
            CreateMap<Variable, VariableResource>().
                ForMember(vr => vr.VariableXlsId, opt => opt.MapFrom(v => v.VariableXls.Id));
            CreateMap<VariableGroup, VariableGroupResource>();
            CreateMap<KeyParameter, KeyParameterResource>();
            CreateMap<KeyParameterGroup, KeyParameterGroupResource>();
            CreateMap<KeyParameterLevel, KeyParameterLevelResource>();
            CreateMap<Data, DataResource>();
            CreateMap<VariableXls, VariableXlsResource>();
            CreateMap<SaveVariableXlsResource, VariableXls>()
                .ForMember(v => v.Id, opt => opt.Ignore());
        }
    }
}