using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System;
using System.Configuration;
using System.Text;

namespace OauthWebClient
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.SetLoggerFactory(new LoggerFactory());

            var securityKey = Convert.FromBase64String(ConfigurationManager.AppSettings["JwtKey"]);
            string validIssuer = ConfigurationManager.AppSettings["JwtIssuer"];

            var tokenValidationParameters = new TokenValidationParameters()
            {

                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = validIssuer,
                ValidAudience = "",
                IssuerSigningKey = new SymmetricSecurityKey(securityKey)
            };

            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = tokenValidationParameters
                });
        }
    }
}
