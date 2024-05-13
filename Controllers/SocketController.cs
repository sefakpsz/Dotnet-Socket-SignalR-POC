using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SignalR_Poc.Constants;
using SignalR_Poc.Models;
using SignalR_Poc.Services;

namespace SignalR_Poc.Controllers;

[Route("api/socket")]
[ApiController]
public class SocketController(ISocketService socketService) : ControllerBase
{
    private readonly ISocketService _socketService = socketService;

    [HttpPost("broadcast")]
    public async Task<IActionResult> Broadcast([Required] DataTypes message)
    {
        await _socketService.DataCreated(message);
        return Ok();
    }

    [HttpPost("broadcast_data")]
    public async Task<IActionResult> BroadcastData([Required] SocketModel<DataType1> request)
    {
        await _socketService.DataCreated(request);
        return Ok();
    }
}