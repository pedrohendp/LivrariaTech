using FluentValidation.Results;
using LivrariaTech.Api.Domain.Entities;
using LivrariaTech.Api.Infraestructure.DataAccess;
using LivrariaTech.Api.Infraestructure.Security.Cryptography;
using LivrariaTech.Api.Infraestructure.Security.Tokens.Access;
using LivrariaTech.Communication.Requests;
using LivrariaTech.Communication.Responses;
using LivrariaTech.Exception;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace LivrariaTech.Api.UseCases.Users.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute (RequestUserJson request)
        {
            var dbContext = new LivrariaTechDbContext();

            Validate(request, dbContext);

            var criptografia = new BCryptAlgorithm();

            var entity = new User
            {
                Email = request.Email,
                Name = request.Name,
                Password = criptografia.HashPassword(request.Password)
            };

            dbContext.Users.Add(entity);
            dbContext.SaveChanges();

            var tokenGenerator = new JwtTokenGenerator();

            return new ResponseRegisteredUserJson
            {
                Name = entity.Name,
                AccessToken = tokenGenerator.Generate(entity)

            };
        }

        private void Validate (RequestUserJson request, LivrariaTechDbContext dbContext)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            var existUserWhithEmail = dbContext.Users.Any(user => user.Email.Equals(request.Email));
            if (existUserWhithEmail)
            {
              result.Errors.Add(new ValidationFailure("Email", "E-mail já registrado na plataforma."));
            }

            if (!result.IsValid)
            {
                var errorMessage = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessage);
            }
        }
    }
}
