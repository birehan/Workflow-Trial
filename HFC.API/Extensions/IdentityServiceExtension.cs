using System.Text;
using HFC.API.Services;
using HFC.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using HFC.Persistence;
using HFC.Infrastructure.Security;

namespace HFC.API.Extensions
{
    public static class IdentityServerExtensions
    {

        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentityCore<AppUser>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<HFCDbContext>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(opt =>
                    {
                        opt.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = key,
                            ValidateIssuer = false,
                            ValidateAudience = false
                        };
                    });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("IsTaskCreator", policy =>
                {
                    policy.Requirements.Add(new IsTaskCreatorRequirement());
                });
            });



            services.AddTransient<IAuthorizationHandler, IsTaskCreatorRequirementHandler>();
            services.AddScoped<TokenService>();

            return services;
        }
    }
}
