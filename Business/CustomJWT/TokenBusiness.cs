using Business.Interfaces;
using Data.Interfaces.IDataImplement;
using Entity.DTOs.Implements.User;
using Entity.Models.Implements;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Utilities.Helpers.Token;

namespace Business.CustomJWT
{
    public class TokenBusiness : IToken
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtSettings _jwtSettings;
        private readonly ILogger<TokenBusiness> _logger;

        public TokenBusiness( IUserRepository userRepository, JwtSettings jwtSettings, ILogger<TokenBusiness> logger)
        {
            _userRepository = userRepository;
            _jwtSettings = jwtSettings;
            _logger = logger;
        }

        public async Task<TokenDto> GenerateTokensAsync(AuthDto user)
        {
            var accessToken = BuildAccessToken(user);

            var refreshPlain = TokenHelpers.GenerateSecureRandomUrlToken(64);

            return new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshPlain,
                CsrfToken = TokenHelpers.GenerateSecureRandomUrlToken(32),
                ExpiresAt = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes)
            };
        }

        private string BuildAccessToken(AuthDto user)
        {
            var now = DateTime.UtcNow;
            var exp = now.AddMinutes(_jwtSettings.AccessTokenExpirationMinutes);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, user.EmailOrUsername),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
            };

            claims.Add(new Claim(ClaimTypes.Role, user.role));

            var jwt = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                notBefore: now,
                expires: exp,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
