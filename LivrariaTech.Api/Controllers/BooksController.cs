using LivrariaTech.Api.UseCases.Books.Filter;
using LivrariaTech.Communication.Requests;
using LivrariaTech.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaTech.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet("Filter")]
        [ProducesResponseType(typeof(ResponseBooksJson),StatusCodes.Status200OK)]
        public IActionResult Filter (int pageNumber, string? title)
        {
            var useCase = new FilterBookUseCase();

            var request = new RequestFilterBooksJson
            {
                PageNumber = pageNumber,
                Title = title
            };

            var result = useCase.Execute(request);

            return Ok(result);
        }
    }
}
