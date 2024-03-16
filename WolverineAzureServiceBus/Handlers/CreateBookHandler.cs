using Wolverine.Attributes;
using WolverineAzureServiceBus.Commands;
using WolverineAzureServiceBus.Data;

namespace WolverineAzureServiceBus.Handlers;

[Transactional]
public class CreateBookHandler(IBookRepository bookRepository)
{
    public async Task<int> Handle(CreateBook request)
    {
        return bookRepository.Create(request.Title, request.Author);
    }
}