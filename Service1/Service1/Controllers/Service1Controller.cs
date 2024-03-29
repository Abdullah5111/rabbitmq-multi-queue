﻿using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Service1.Message;
using SharedContent.Message;

[ApiController]
[Route("api/[controller]")]
public class Service1Controller : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public Service1Controller(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost("send-message")]
    public async Task<IActionResult> SendMessage([FromBody] Tokenn1 message)
    {
        await _publishEndpoint.Publish<Tokenn1>(message);
        await _publishEndpoint.Publish<Tokenn2>(message);

        return Ok("Message sent successfully");
    }
}
