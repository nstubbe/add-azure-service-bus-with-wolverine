using Microsoft.AspNetCore.Mvc;
using Wolverine;
using WolverineAzureServiceBus.Commands;
using WolverineAzureServiceBus.Data;
using WolverineAzureServiceBus.Queries;

namespace WolverineAzureServiceBus;

[ApiController]
[Route("api/book")]
public class BookController(IMessageBus messageBus) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await messageBus.InvokeAsync<Book>(new BookQuery(id));
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateBook command)
    {
        var result = await messageBus.InvokeAsync<int>(command);
        return Ok(result);
    }
}