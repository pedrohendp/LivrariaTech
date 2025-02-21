using FluentValidation;
using LivrariaTech.Communication.Requests;

namespace LivrariaTech.Api.UseCases.Users.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestUserJson>
    {
        public RegisterUserValidator ()
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage("O nome é obrigatório.");
            RuleFor(request => request.Email).EmailAddress().WithMessage("O e-mail é inválido.");
            RuleFor(request => request.Password).NotEmpty().WithMessage("A senha é obrigatória.");
            
            When(request => string.IsNullOrEmpty(request.Password) == false, () => 
            { 
                RuleFor(request => request.Password).NotEmpty().MinimumLength(6).WithMessage("A senha deve ser maior ou igual a 6 caracteres."); 
            });
        }
    }
}