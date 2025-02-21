using LivrariaTech.Api.UseCases.Users.Register;
using LivrariaTech.Communication.Requests;
using LivrariaTech.Communication.Responses;
using LivrariaTech.Exception;
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
        public IActionResult Create (RequestUserJson request)
        {
            try
            {
                var useCase = new RegisterUserUseCase();

                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch (LivrariaTechException ex)
            {
                return BadRequest(new ResponseErrorMessagesJson
                {
                    Errors = ex.GetErrorMessages()
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson
                {
                    Errors = ["Erro desconhecido"]
                });
            }
        }
    }
}
