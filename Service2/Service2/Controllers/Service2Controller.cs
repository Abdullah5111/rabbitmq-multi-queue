using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SharedContent.Message;

namespace Service2.Controllers
{
    public class Service2Controller : Controller
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public Service2Controller(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost("send-notification")]
        public async Task<IActionResult> SendMessage([FromBody] Notification notification)
        {
            await _publishEndpoint.Publish<Notification>(notification);

            return Ok("Message sent successfully");
        }
    }
}
