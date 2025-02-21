using LivrariaTech.Api.Domain.Entities;
using LivrariaTech.Api.Infraestructure;
using LivrariaTech.Communication.Requests;
using LivrariaTech.Communication.Responses;
using LivrariaTech.Exception;

namespace LivrariaTech.Api.UseCases.Users.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisteredUserJson Execute (RequestUserJson request)
        {
            Validate(request);

            var entity = new User
            {
                Email = request.Email,
                Name = request.Name,
                Password = request.Password
            };

            var dbContext = new LivrariaTechDbContext();

            dbContext.Users.Add(entity);
            dbContext.SaveChanges();

            return new ResponseRegisteredUserJson
            {
                Name = entity.Name
            };
        }

        private void Validate (RequestUserJson request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessage = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessage);
            }
        }
    }
}
