using Microsoft.AspNetCore.Mvc;

namespace SendingMessagesService.Utils
{
    public class BaseController : Controller
    {
        protected new IActionResult Ok()
        {
            return base.Ok(Envelope.Ok());
        }

        protected IActionResult Ok<T>(T result)
        {
            return base.Ok(Envelope.Ok(result));
        }

        protected IActionResult Error(string errorMessage)
        {
            return base.BadRequest(Envelope.Error(errorMessage));
        }

        protected IActionResult NotFound(string errorMessage)
        {
            return base.NotFound(Envelope.Error(errorMessage));
        }

        protected IActionResult Created()
        {
            return base.StatusCode(201);
        }
    }
}
