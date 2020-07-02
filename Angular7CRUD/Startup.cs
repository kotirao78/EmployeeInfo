using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security.Jwt;
using Owin;

[assembly: OwinStartup(typeof(Angular7CRUD.Startup))]

namespace Angular7CRUD
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience=true,
                    ValidateIssuerSigningKey=true,
                    ValidIssuer= "http://mysite.com",
                    ValidAudience= "http://mysite.com",
                    IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sfasdfasldasndfaskdjfaskfjhasjdfsh"))
        }
            });
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
