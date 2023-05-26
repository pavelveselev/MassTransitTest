using Common.Messages;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private static int Count = 0;

    private readonly IBus _bus;

    public TestController(IBus bus)
    {
        _bus = bus;
    }

    [HttpGet]
    public async Task Get()
    {
        var message = new TestMessage
        {
            Id = Count++,
            TimeStamp = DateTime.Now,
        };
        await _bus.Send<TestMessage>(message);
    }
}
