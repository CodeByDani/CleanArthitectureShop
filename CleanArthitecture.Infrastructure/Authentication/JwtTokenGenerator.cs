using CleanArthitecture.Application.Common.Interfaces.Authentication;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Common.Helper;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CleanArthitecture.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Options;

namespace CleanArthitecture.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IDateTimeProvider _dateTimeProvider;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider,IOptions<JwtSettings> jwtOptions)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSettings = jwtOptions.Value;

        }

        public string GenerateToken(long customerId, string firstName, string lastName)
        {
            var siginingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256); 

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,customerId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName,firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName,lastName),
                new Claim(JwtRegisteredClaimNames.Jti,LongExxtention.GenerateLongRandom().ToString())
            };
            var SecurityToken = new JwtSecurityToken(
                issuer:_jwtSettings.Issuer,
                audience:_jwtSettings.Audience,
                expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                claims: claims,
                signingCredentials: siginingCredentials);
        }
    }
}
