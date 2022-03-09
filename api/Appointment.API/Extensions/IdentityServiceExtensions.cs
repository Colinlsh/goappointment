using Appointment.Application.Core.Interfaces;
using Appointment.Infrastructure.Aws.Cognito;
using Appointment.Infrastructure.Aws.Models;
using Appointment.Infrastructure.Constants;
using Appointment.Infrastructure.Contracts;
using Appointment.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            // services.AddIdentityCore<AppUser>(opt =>
            // {
            //     opt.Password.RequireNonAlphanumeric = false;
            //     opt.SignIn.RequireConfirmedEmail = true;
            // })
            //     .AddEntityFrameworkStores<AppointmentDataContext>()
            //     // this allow us to create token for confirm email
            //     .AddDefaultTokenProviders();

            // services.AddIdentityCore<DashboardSuperAdminUser>(opt =>
            // {
            //     opt.Password.RequireNonAlphanumeric = false;
            //     opt.SignIn.RequireConfirmedEmail = true;
            // })
            // .AddEntityFrameworkStores<AppointmentMainDataContext>()
            // // this allow us to create token for confirm email
            // .AddDefaultTokenProviders();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));

            var awsconfig = config.GetSection("AWS");
            services.Configure<AwsConfiguration>(awsconfig);
            var awsconfiguration = awsconfig.Get<AwsConfiguration>();

            var awsCognitoSetting = config.GetSection("AWS:Cognito");
            services.Configure<AwsCongitoSetting>(awsCognitoSetting);
            var cognitoSetting = awsCognitoSetting.Get<AwsCongitoSetting>();

            services.AddSingleton<IAwsCognitoIdentityClient, AwsCognitoIdentityClient>();
            services.AddScoped<IAwsCognitoCommandService, AwsCognitoCommandService>();

            services.AddCognitoIdentity();

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(opt =>
                {
                    opt.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            return Task.CompletedTask;
                        },
                        OnForbidden = context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                            return Task.CompletedTask;
                        },
                        OnChallenge = context =>
                        {
                            return Task.CompletedTask;
                        },

                    };

                    opt.RequireHttpsMetadata = false;
                    opt.SaveToken = true;
                    opt.TokenValidationParameters = cognitoSetting.TokenValidationParameters;
                })
                .AddGoogle(opt =>
                {
                    var googleAuthSection = config.GetSection("Google");

                    opt.ClientId = googleAuthSection["ClientId"];
                    opt.ClientSecret = googleAuthSection["ClientSecret"];

                })
                .AddFacebook(opt =>
                {
                    var facebookAuthSection = config.GetSection("Facebook");

                    opt.AppId = facebookAuthSection["AppId"];
                    opt.AppSecret = facebookAuthSection["AppSecret"];
                });

            //services.AddAuthorization(opt =>
            //{
            //    opt.AddPolicy(ClaimPolicy.SuperAdmin, policy => policy.RequireRole(LoginRole.Admin.GetDescription()));
            //    opt.AddPolicy(ClaimPolicy.User, policy => policy.RequireRole(LoginRole.User.GetDescription()));
            //});

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy(SpecialAuthorization.IsActivityHost, policy =>
                {
                    policy.Requirements.Add(new IsHostRequirement());
                });

                opt.AddPolicy(SpecialAuthorization.SuperAdmin, policy =>
                {
                    policy.Requirements.Add(new IsSuperAdminRequirement());
                });

                opt.AddPolicy(SpecialAuthorization.Admin, policy =>
                {
                    policy.Requirements.Add(new IsAdminRequirement());
                });
            });

            services.AddTransient<IAuthorizationHandler, IsHostRequirementHandler>();
            services.AddTransient<IAuthorizationHandler, IsSuperAdminRequirementHandler>();
            services.AddTransient<IAuthorizationHandler, IsAdminRequirementHandler>();
            services.AddScoped<IVerifyExternalLoginService, VerifyExternalLoginService>();

            return services;
        }
    }
}
