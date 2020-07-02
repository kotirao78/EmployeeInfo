using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;

namespace Angular7CRUD.Controllers
{
    public class AuthController : ApiController
    {

        private static string secret = Guid.NewGuid().ToString();
        [HttpGet]
        public object Token()
        {
            string key = "sfasdfasldasndfaskdjfaskfjhasjdfsh";
            var issuer = "http://mysite.com";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("Valid", "1"));
            permClaims.Add(new Claim("userid", "1"));
            permClaims.Add(new Claim("name", "bilal"));
            var token = new JwtSecurityToken(issuer, issuer, permClaims, expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials
                );
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return new { data = jwt_token };
            //byte[] key = Convert.FromBase64String(secret);
            //var header = Request.Headers["Authorization"];
            //if (header.ToString().StartsWith("Basic"))
            //{
            //    var credvalue = header.ToString().Substring("Basic".Length).Trim();
            //    var usernameandpass = Encoding.UTF8.GetString(Convert.FromBase64String(credvalue));
            //    var usernamepass = usernameandpass.Split(":");
            //    if (usernamepass[0] == "Admin" && usernamepass[1] == "pass")
            //    {
            //        var claimdata = new[] { new Claim(ClaimTypes.Name, usernamepass[0]) };
            //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sdjsdfdsjfsdfjsdf"));
            //        var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            //        var tokenstring = new JwtSecurityToken(
            //            issuer: "mysite.com",
            //            audience: "mysite.com",
            //            expires: DateTime.Now.AddMinutes(10),
            //            claims: claimdata,
            //            signingCredentials: signInCred);
            //        var token = new JwtSecurityTokenHandler().WriteToken(tokenstring);
            //        //   string tokenstring = "test";
            //        return Ok(token);
            //    }

            // }


    //        return BadRequest("Wrong Request");

            // }
        }
    }
}
