using LivrariaTech.Api.Infraestructure.DataAccess;
using LivrariaTech.Api.Infraestructure.Security.Cryptography;
using LivrariaTech.Api.Infraestructure.Security.Tokens.Access;
using LivrariaTech.Communication.Requests;
using LivrariaTech.Communication.Responses;
using LivrariaTech.Exception;

namespace LivrariaTech.Api.UseCases.Login.DoLogin
{
    public class DoLoginUseCase
    {
        public ResponseRegisteredUserJson Execute (RequestLoginJson request)
        {
            var dbContext = new LivrariaTechDbContext();

            var user = dbContext.Users.FirstOrDefault(users => users.Email.Equals(request.Email)) ?? throw new InvalidLoginException();

            var cryptography = new BCryptAlgorithm();

            var passwordIsValid = cryptography.Verify(request.Password, user);

            if (!passwordIsValid)
            {
                throw new InvalidLoginException();
            }
            
            var tokenGenerator = new JwtTokenGenerator();
            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
                AccessToken = tokenGenerator.Generate(user)
            };
        }
    }
}
