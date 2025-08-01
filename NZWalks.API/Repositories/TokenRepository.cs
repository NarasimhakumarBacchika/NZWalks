﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NZWalks.API.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        //private readonly IConfiguration configuration;
        //public TokenRepository(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //}



        //public string CreateJwtToken(IdentityUser user, List<string> roles)
        //{
        //    var claims = new List<Claim>();
        //    {
        //        claims.Add(new Claim(ClaimTypes.Email, user.Email));
        //    }
        //    ;

        //    foreach (var role in roles)
        //    {
        //        {

        //            claims.Add(new Claim(ClaimTypes.Role, role));
        //        }

        //    }

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        //    var credicial = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //    var token = new JwtSecurityToken(

        //        configuration["Jwt:Issuer"],
        //        configuration["Jwt:Audience"],
        //        claims,
        //        expires:DateTime.Now.AddMinutes(15),
        //        signingCredentials: credicial);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
            private readonly IConfiguration configuration;

            public TokenRepository(IConfiguration configuration)
            {
                this.configuration = configuration;
            }

            public string CreateJwtToken(IdentityUser user, List<string> roles)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
        };

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: configuration["Jwt:Issuer"],
                    audience: configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }

    
}
