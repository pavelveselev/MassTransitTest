using Common.Messages;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestClientController : ControllerBase
    {
        private static int Count = 0;
        private readonly IRequestClient<TestClientMessage> _requestClient;

        public TestClientController(IRequestClient<TestClientMessage> requestClient)
        {
            _requestClient = requestClient;
        }

        [HttpGet]
        public async Task Get(CancellationToken cancellationToken)
        {
            var testClientMessage = new TestClientMessage
            {
                Id = Count++,
                TimeStamp = DateTime.Now,
            };
            var result = await _requestClient.GetResponse<ITestClientResultMessage>(testClientMessage, cancellationToken);
        }
    }
}
