using Common.Messages;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private static int Count = 0;
    private readonly ISendEndpointProvider _sendEndpointProvider;

    public TestController(ISendEndpointProvider sendEndpointProvider)
    {
        _sendEndpointProvider = sendEndpointProvider;
    }

    [HttpGet]
    public async Task Get()
    {
        var message = new TestMessage
        {
            Id = Count++,
            TimeStamp = DateTime.Now,
        };

        await _sendEndpointProvider.Send<TestMessage>(message);
    }
}
