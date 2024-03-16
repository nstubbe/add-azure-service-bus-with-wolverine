using Wolverine.Attributes;
using WolverineAzureServiceBus.Data;
using WolverineAzureServiceBus.Queries;

namespace WolverineAzureServiceBus.Handlers;

[Transactional]
public class BookQueryHandler(IBookRepository bookRepository)
{
    public Book? Handle(BookQuery request)
    {
        return bookRepository.GetById(request.Id);
    }
}