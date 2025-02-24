using LivrariaTech.Api.UseCases.Login.DoLogin;
using LivrariaTech.Communication.Requests;
using LivrariaTech.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaTech.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status401Unauthorized)]
        public IActionResult DoLogin (RequestLoginJson request)
        {
            var useCase = new DoLoginUseCase();

            var response = useCase.Execute(request);

            return Ok(response);
        }
    }
}
