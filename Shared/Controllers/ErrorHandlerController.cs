using Gisfpp_projects.Shared.Exceptions;
using Gisfpp_projects.Shared.Model;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Gisfpp_projects.Shared.Controllers
{
    [ApiController]
    public class ErrorHandlerController : ControllerBase
    {
        private readonly ILogger<ErrorHandlerController> _logger;

        public ErrorHandlerController(ILogger<ErrorHandlerController> logger)
        {
            _logger = logger;
        }

        [Route("/errors")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GenericHandlerError()
        {
            var errorException = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            var nameException = errorException?.GetType().Name switch
            {
                "ModelInvalidException" => new
                {
                    message = ((ModelInvalidException)errorException).GetMessageValidations(),
                    statusCode = HttpStatusCode.BadRequest
                },
                _ => new
                {
                    message = MessagesConstant.MSG_UNEXPECTED_ERROR,
                    statusCode = HttpStatusCode.InternalServerError
                },
            };
            var originException = errorException?.InnerException ?? errorException;

            _logger.LogError(originException, originException?.Message);

            return Problem(detail: nameException.message, statusCode: (int)nameException.statusCode);
        }
    }
}
