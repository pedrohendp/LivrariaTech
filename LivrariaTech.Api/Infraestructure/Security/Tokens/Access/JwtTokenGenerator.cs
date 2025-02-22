using LivrariaTech.Api.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LivrariaTech.Api.Infraestructure.Security.Tokens.Access
{
    public class JwtTokenGenerator
    {
        public string Generate(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
              Expires = DateTime.UtcNow.AddMinutes(60),
              Subject = new ClaimsIdentity(claims),
              SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }

        /// <summary>
        /// Método responsável por gerar a chave de segurança
        /// signingKey nunca deve ser exposta (utilizando desta forma em ambiente de testes)
        /// </summary>
        /// <returns></returns>
        private SymmetricSecurityKey SecurityKey ()
        {
            var signingKey = "jq3ksb0aRae8IKgbfirWqY8GUyhq9vno";

            var symetricKey = Encoding.UTF8.GetBytes(signingKey);

            return new SymmetricSecurityKey(symetricKey);
        }
    }
}