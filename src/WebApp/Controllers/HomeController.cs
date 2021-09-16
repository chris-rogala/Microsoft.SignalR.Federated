using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Hubs;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SecureSpecialMessageHub _hub;

        public HomeController(ILogger<HomeController> logger,
            SecureSpecialMessageHub hub)
        {
            _logger = logger;
            _hub = hub;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("SecureSpecialMessageHubBlazor")]
        public IActionResult SecureSpecialMessageHubBlazor()
        {
            return View();
        }

        [Route("SecureSpecialMessageHubJavaScript")]
        public IActionResult SecureSpecialMessageHubJavaScript()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        [HttpPost("customers/{customerId}/send-message")]
        public async Task<IActionResult> SendMessagesAsync([FromRoute] string customerId, [FromBody] SendSpecialMessage message, CancellationToken cancellationToken)
        {
            await _hub.SendMessage(customerId, message, cancellationToken);

            return NoContent();
        }
    }
}
