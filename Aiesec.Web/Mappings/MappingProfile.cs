using Microsoft.AspNetCore.Mvc.Rendering;
using Profile = AutoMapper.Profile;

namespace Aiesec.Web.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            // Database.ApplicationUser
            CreateMap<Database.Models.ApplicationUser, Database.Models.ApplicationUser>().ReverseMap();
            CreateMap<Database.Models.ApplicationUser, Model.Response.Administration.User>().ReverseMap();
            CreateMap<Database.Models.ApplicationUser, Model.Request.Administration.User>().ReverseMap();
            CreateMap<Model.Update.Administration.User, Database.Models.ApplicationUser>();
            // Database.Profile
            CreateMap<Database.Models.Profile, Model.Response.Administration.Profile>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City));
            CreateMap<Model.Request.Administration.Profile, Database.Models.Profile>();
            CreateMap<Model.Update.Administration.Profile, Database.Models.Profile>();
            // Database.City
            CreateMap<Database.Models.City, Model.Response.Administration.City>();
            // Database.LocalCommittee
            CreateMap<Model.Request.Administration.LocalCommittee, Database.Models.LocalCommittee>();
            CreateMap<Database.Models.LocalCommittee, Model.Response.Administration.LocalCommittee>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City));
            CreateMap<Model.Update.Administration.LocalCommittee, Database.Models.LocalCommittee>();
            // Database.MemberCommittee
            CreateMap<Database.Models.MemberCommittee, Model.Response.Administration.MemberCommittee>();
            CreateMap<Model.Request.Administration.MemberCommittee, Database.Models.MemberCommittee>();
            // Database.FunctionalFieldType
            CreateMap<Database.Models.FunctionalFieldType, Model.Response.Administration.FunctionalFieldType>();
            // Database.Team
            CreateMap<Model.Request.Administration.Team, Database.Models.Team>();
            CreateMap<Database.Models.Team, Model.Response.Administration.Team>()
                .ForMember(dest => dest.FunctionalFieldType, opt => opt.MapFrom(src => src.FunctionalFieldType))
                .ForMember(dest => dest.LocalCommittee, opt => opt.MapFrom(src => src.LocalCommittee));
            CreateMap<Model.Update.Administration.Team, Database.Models.Team>();
            // Database.Office 
            CreateMap<Database.Models.Office, Model.Response.Administration.Office>()
                .ForMember(dest => dest.LocalCommittee, opt => opt.MapFrom(src => src.LocalCommittee));
            CreateMap<Model.Request.Administration.Office, Database.Models.Office>();
            CreateMap<Model.Update.Administration.Office, Database.Models.Office>();


            #region Select lists
            // Database.City
            CreateMap<Database.Models.City, SelectListItem>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id.ToString()))
                .ReverseMap();
            // Datababase.ApplicationRole
            CreateMap<Database.Models.ApplicationRole, SelectListItem>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id.ToString()));
            // Database.LocalCommittee
            CreateMap<Database.Models.LocalCommittee, SelectListItem>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id.ToString()));
            // Database.FunctionalFieldType
            CreateMap<Database.Models.FunctionalFieldType, SelectListItem>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id.ToString()));
            #endregion
        }
    }
}
