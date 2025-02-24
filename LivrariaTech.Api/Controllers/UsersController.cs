using LivrariaTech.Api.UseCases.Users.Register;
using LivrariaTech.Communication.Requests;
using LivrariaTech.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaTech.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register (RequestUserJson request)
        {
            var useCase = new RegisterUserUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
