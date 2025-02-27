using LivrariaTech.Api.Infraestructure.Services.LoggedUser;
using LivrariaTech.Api.UseCases.Checkouts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaTech.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CheckoutsController : ControllerBase
    {
        [HttpPost]
        [Route("{bookId}")]
        public IActionResult BookCheckout (Guid bookId)
        {
            var loggedUser = new LoggedUserService(HttpContext);

            var usecase = new RegisterBookCheckoutUseCase(loggedUser);
            usecase.Execute(bookId);

            return NoContent();
        }
    }
}
