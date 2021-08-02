using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// Angular Authentication Functionality with ASP.NET Core Identity
// https://code-maze.com/angular-authentication-aspnet-identity/
namespace ERPAPI.Auth
{
    public class JwtHandler
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;
        private DateTime _defineExpireTime;
        public JwtHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("JWTSettings");

            _defineExpireTime = DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.GetSection("ExpiryInMinutes").Value));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("SignatureKey").Value);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        /// <summary>
        /// step 2. build calims 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Claim> GetClaims(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff")),
                new Claim(JwtRegisteredClaimNames.Exp, _defineExpireTime.ToString("yyyy-MM-dd HH:mm:ss.ffff"))
            };
            return claims;
        }
        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            // step 3. build calims 
            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["AppSettings:Jwt:ValidIssuer"],
                audience: _configuration["AppSettings:Jwt:ValidAudience"],
                claims: claims,
                expires: _defineExpireTime,
                signingCredentials: signingCredentials);
            return tokenOptions;
        }
    }
}
