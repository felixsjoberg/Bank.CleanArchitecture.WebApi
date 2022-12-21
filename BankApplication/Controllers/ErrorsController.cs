using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Api.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            //accessing the thrown exception.
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            return Problem();
        }
    }
}


