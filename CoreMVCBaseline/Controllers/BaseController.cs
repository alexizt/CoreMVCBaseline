using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoreMVCBaseline.Controllers
{
    public abstract class BaseController<TResult> : Controller
    {
        protected readonly ILogger<TResult> _logger;

        protected BaseController(
            ILogger<TResult> logger
            )
        {
            _logger = logger;
        }

    }
}
