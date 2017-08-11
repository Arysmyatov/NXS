using AutoMapper;
using NXS.Controllers.Resources;
using NXS.Core;
using NXS.Core.Models;

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
            CreateMap<DataQueryResource, DataQuery>();
            CreateMap<VariableXls, VariableXlsResource>();
            CreateMap<XlsRegionType, XlsRegionTypeResource>();
            CreateMap<SaveVariableXlsResource, VariableXls>();
            CreateMap<XlsUpload, XlsUploadResource>();
            CreateMap<UserProfileResource, NxsUser>();
            CreateMap<NxsUser, UserProfileResource>();
            CreateMap<RegistrationInfoResource, NxsUser>()
                .ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));

        }
    }
}