using Microsoft.AspNetCore.Mvc;

namespace LivrariaTech.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create ()
        {
            return Created();
        }
    }
}
