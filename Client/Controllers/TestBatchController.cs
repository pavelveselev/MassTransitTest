using Common.Messages;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestBatchController : ControllerBase
    {
        private static int Count = 0;
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public TestBatchController(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        [HttpGet]
        public async Task Get()
        {
            var message = new TestBatchMessage
            {
                Id = Count++,
                TimeStamp = DateTime.Now,
            };

            await _sendEndpointProvider.Send(message);
        }
    }
}
