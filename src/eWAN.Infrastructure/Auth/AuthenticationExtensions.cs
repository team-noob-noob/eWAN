using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace eWAN.Infrastructure.Auth
{

    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(System.Environment.GetEnvironmentVariable("SERVER_KEY"));

            services
            .AddAuthentication(x => {
                x.DefaultScheme = "Cookies";
                x.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", x => {
                x.Authority = "https://localhost:5001";

                x.ClientId = "mvc";
                x.ClientSecret = "secret";
                x.ResponseType = "code";

                x.SaveTokens = true;
            });

            // services.AddAuthorization(options => {
            //     var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);
            //     defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
            //     options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            // });

            return services;
        }
    }
}
