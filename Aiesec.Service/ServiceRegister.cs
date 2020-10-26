using Aiesec.Service.IServices;
using Aiesec.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Aiesec.Service
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<ILocalCommitteeService, LocalCommitteeService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<IMemberCommitteeService, MemberCommitteeService>();
            return services;
        }
    }
}