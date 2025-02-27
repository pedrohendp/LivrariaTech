using LivrariaTech.Api.Domain.Entities;
using LivrariaTech.Api.Infraestructure.DataAccess;
using System.IdentityModel.Tokens.Jwt;

namespace LivrariaTech.Api.Infraestructure.Services.LoggedUser
{
    public class LoggedUserService
    {
        private readonly HttpContext _httpContext;
        public LoggedUserService (HttpContext httpContext)
        {
            _httpContext = httpContext;
        }
        public User GetUser (LivrariaTechDbContext dbContext)
        {
            var auth = _httpContext.Request.Headers.Authorization.ToString();
            var token = auth["Bearer ".Length..].Trim();

            var tokenHandler = new JwtSecurityTokenHandler();

            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

            var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value;

            var userId = Guid.Parse(identifier);

            return dbContext.Users.First(user => user.Id == userId);
        }
    }
}