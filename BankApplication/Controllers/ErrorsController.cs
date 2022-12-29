using BankApplication.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Api.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error")]
        public IActionResult Error()
        {
            //accessing the thrown exception.
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statusCode, message) = exception switch
            {
                DuplicateEmailException => (StatusCodes.Status409Conflict, "User already exists."),
                InvalidUser => (StatusCodes.Status404NotFound, "User doesn't exists."),
                InvalidPassword=> (StatusCodes.Status400BadRequest, "Invalid Password or Username combination.")
            };
            return Problem(statusCode: statusCode, title: message);
        }
    }
}
